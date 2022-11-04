namespace EXU2_Herrera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class DETALLE_PEDIDO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPEDIDO { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPRODUCTO { get; set; }

        public int? PRECIO { get; set; }

        public int? CANTIDAD { get; set; }

        public virtual PEDIDO PEDIDO { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }

        public List<DETALLE_PEDIDO> Listar()
        {
            var query = new List<DETALLE_PEDIDO>();

            try
            {
                using (var db = new Model1())
                {

                    query = db.DETALLE_PEDIDO.Include("PEDIDO").Include("PRODUCTO").ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return query;
        }
        public List<DETALLE_PEDIDO> Buscar(int id)
        {
            var query = new List<DETALLE_PEDIDO>();

            try
            {
                using (var db = new Model1())
                {


                    query = db.DETALLE_PEDIDO.Include("PEDIDO").Include("PRODUCTO")
                           .Where(x => x.IDPEDIDO==id)
                           .ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return query;
        }
    }
}
