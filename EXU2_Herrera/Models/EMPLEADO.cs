namespace EXU2_Herrera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;

    [Table("EMPLEADO")]
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            USUARIO = new HashSet<USUARIO>();
        }

        [Key]
        public int IDEMPLEADO { get; set; }

        [Required]
        [StringLength(80)]
        public string DNI { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(150)]
        public string APELLIDO { get; set; }

        [Required]
        [StringLength(150)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string CELULAR { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DIRECCION { get; set; }

        [Required]
        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }

        public List<EMPLEADO> Listar()
        {
            var query = new List<EMPLEADO>();

            try
            {
                using (var db = new Model1())
                {

                    query = db.EMPLEADO.Where(x=>x.ESTADO.Equals("A")).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return query;
        }
        public EMPLEADO Obtener(int id) 
        {
            var query = new EMPLEADO();

            try
            {
                using (var db = new Model1())
                {
                  

                    query = db.EMPLEADO
                            .Where(x => x.IDEMPLEADO == id)
                            .SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return query;
        }
        public void Guardar()
        {

            try
            {
                using (var db = new Model1())
                {
                    

                    if (this.IDEMPLEADO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Eliminar()
        {

            try
            {
                using (var db = new Model1())
                {

                    db.Entry(this).State = EntityState.Deleted;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
