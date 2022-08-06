using ListOrganizer.Repo.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListOrganizer.Repo
{
    public class BaseRepo : IDisposable
    {
        private ItemInventoryContext db;
        private bool disposed;

        public string Error { get; private set; }

        public readonly static DateTime MinDateSQL = new DateTime(1900, 1, 1);
        public readonly static DateTime MaxDateSQL = new DateTime(2100, 1, 1);

        public BaseRepo(DbContextOptions<ItemInventoryContext> options)
        {
            db = new ItemInventoryContext(options);
        }

        public ItemInventoryContext Db
        {
            get { return db ?? (db = new ItemInventoryContext()); }
            protected set { db = value; }
        }

        protected bool SaveDbChanges()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (DbUpdateException eve)
            {
                var sb = new StringBuilder();
                foreach (var ve in eve.Entries)
                {
                    sb.AppendLine(
                        string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            ve.Entity.GetType().Name, ve.State));

                    var validationResults = new List<ValidationResult>();
                    Validator.TryValidateObject(ve, new ValidationContext(ve), validationResults);

                    foreach (var verr in validationResults)
                    {
                        sb.AppendLine(string.Format("- Error: \"{0}\"", verr.ErrorMessage));
                    }
                }
                Error = sb.ToString();
                return false;
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }

            return true;
        }

        #region Static Methods

        public static DateTime NormalizeSqlDateTime(DateTime test)
        {
            if (test <= MinDateSQL)
                return MinDateSQL;

            if (test >= MaxDateSQL)
                return MaxDateSQL;

            return test;
        }

        #endregion

        #region IDisposable members

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }

            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseRepo()
        {
            Dispose(false);
        }

        #endregion
    }
}
