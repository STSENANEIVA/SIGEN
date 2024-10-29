using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;
using Utilities;

namespace Logic
{
    public class LIngresosAreasTecnicas
    {
        DIngresosAreasTecnicas objDIngresosAreasTecnicas;

        public LIngresosAreasTecnicas()
        {
            objDIngresosAreasTecnicas = new DIngresosAreasTecnicas();
        }

        public IngresosAreasTecnicas Guardar(int idAreaTecnica, int idIngreso)
        {
            try
            {
                ValidarCampos(idAreaTecnica, idIngreso);

                objDIngresosAreasTecnicas = new DIngresosAreasTecnicas();
                IngresosAreasTecnicas objIngresosAreasTecnicas = new IngresosAreasTecnicas();
                objIngresosAreasTecnicas.AreaTecnica = new AreaTecnica { Id = idAreaTecnica };
                objIngresosAreasTecnicas.Ingreso = new Ingreso { Id = idIngreso };
                objIngresosAreasTecnicas.Id = objDIngresosAreasTecnicas.Guardar(objIngresosAreasTecnicas);
                return objIngresosAreasTecnicas;
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IngresosAreasTecnicas Actualizar(int id, int idAreaTecnica, int idIngreso)
        {
            try
            {
                ValidarCampos(idAreaTecnica, idIngreso);

                IngresosAreasTecnicas objIngresosAreasTecnicas = objDIngresosAreasTecnicas.Consultar(id);
                if (objIngresosAreasTecnicas.Equals(null))
                {
                    throw new ApplicationException(Message.IngresosAreasTecnicasNull);
                }

                objDIngresosAreasTecnicas = new DIngresosAreasTecnicas();
                objIngresosAreasTecnicas.AreaTecnica = new AreaTecnica { Id = idAreaTecnica};
                objIngresosAreasTecnicas.Ingreso = new Ingreso { Id = idIngreso };
                objDIngresosAreasTecnicas.Actualizar(objIngresosAreasTecnicas);
                return objIngresosAreasTecnicas;
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<IngresosAreasTecnicas> Consultar()
        {
            try
            {
                return objDIngresosAreasTecnicas.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<IngresosAreasTecnicas>> Consultar(int top, int posicion)
        {
            try
            {
                return objDIngresosAreasTecnicas.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IngresosAreasTecnicas Consultar(int id)
        {
            try
            {
                return objDIngresosAreasTecnicas.Consultar(id);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        public void Eliminar(int id)
        {
            try
            {
                IngresosAreasTecnicas IngresosAreasTecnicas = objDIngresosAreasTecnicas.Consultar(id);
                if (IngresosAreasTecnicas != null)
                {
                    objDIngresosAreasTecnicas.Eliminar(IngresosAreasTecnicas);
                }
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarCampos(int idAreaTecnica, int idIngreso)
        {
           
          
            if (String.IsNullOrEmpty(idAreaTecnica.ToString()))
            {
                throw new ApplicationException(Message.AreaTecnicaVacio);
            }
            if (String.IsNullOrEmpty(idIngreso.ToString()))
            {
                throw new ApplicationException(Message.IngresoVacio);
            }
        }

        public IngresosAreasTecnicas ConsultarPorAreaTecnica(int id)
        {
            try
            {
                return objDIngresosAreasTecnicas.ConsultarPorAreaTecnica(id);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
