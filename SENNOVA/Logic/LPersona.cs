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
    public class LPersona
    {
        DPersona objDPersona;

        public LPersona()
        {
            objDPersona = new DPersona();
        }

        public Persona Guardar(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email,  int idTipoDocumento)
        {
            try
            {
                ValidarCampos(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);

                objDPersona = new DPersona();
                Persona objPersona = new Persona();
                objPersona.Codigo = GenerarCodigo();
                objPersona.Nombres = nombres;
                objPersona.Apellidos = apellidos;
                objPersona.NumeroIdentificacion = numeroIdentificacion;
                objPersona.Telefono = telefono;
                objPersona.Email = email;
                objPersona.TipoDocumento = new TipoDocumento() { Id = idTipoDocumento};
                objPersona.Id = objDPersona.Guardar(objPersona);
                return objPersona;
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

        public Persona Actualizar(int id, string nombres, string apellidos, string numeroIdentificacion, string telefono, string email, int idTipoDocumento)
        {
            try
            {
                ValidarCampos(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);

                Persona objPersona = objDPersona.Consultar(id);
                if (objPersona.Equals(null))
                {
                    throw new ApplicationException(Message.PersonaNull);
                }

                objDPersona = new DPersona();
                objPersona.Nombres = nombres;
                objPersona.Apellidos = apellidos;
                objPersona.NumeroIdentificacion = numeroIdentificacion;
                objPersona.Telefono = telefono;
                objPersona.Email = email;
                objPersona.TipoDocumento = new TipoDocumento() { Id = idTipoDocumento };
                objDPersona.Actualizar(objPersona);
                return objPersona;
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

        public List<Persona> Consultar()
        {
            try
            {
                return objDPersona.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Persona>> Consultar(int top, int posicion)
        {
            try
            {
                return objDPersona.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Persona Consultar(int idTipoDocumento, string numeroIdentificacion)
        {
            try
            {
                return objDPersona.ConsultarPorTipoNumero(idTipoDocumento, numeroIdentificacion);
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

        public Persona Consultar(int id)
        {
            try
            {
                return objDPersona.Consultar(id);
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

        public Persona ConsultarUltimoRegistro()
        {
            try
            {
                return objDPersona.ConsultarUltimoRegistro();
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

        public Persona Consultar(string codigo)
        {
            try
            {
                return objDPersona.Consultar(codigo);
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
                Persona Persona = objDPersona.Consultar(id);
                if (Persona != null)
                {
                    objDPersona.Eliminar(Persona);
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

        private void ValidarCampos(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email, int idTipoDocumento)
        {
            if (String.IsNullOrEmpty(nombres))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
            if (String.IsNullOrEmpty(apellidos))
            {
                throw new ApplicationException(Message.ApellidoVacio);
            }
            if (String.IsNullOrEmpty(numeroIdentificacion))
            {
                throw new ApplicationException(Message.numeroIdentificacionVacio);
            }
            if (String.IsNullOrEmpty(telefono))
            {
                throw new ApplicationException(Message.TelefonoVacio);
            }
            if (String.IsNullOrEmpty(email))
            {
                throw new ApplicationException(Message.EmailVacio);
            }
           
            if (String.IsNullOrEmpty(idTipoDocumento.ToString()))
            {
                throw new ApplicationException(Message.TipoDocumentoVacio);
            }
           
        }

        public Persona ConsultarPorTipoDocumento(int id)
        {
            try
            {
                return objDPersona.ConsultarPorTipoDocumento(id);
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

        public string GenerarCodigo()
        {
            string consecutivo = "";
            DateTime fecha = DateTime.Now;
            List<Persona> lstClientes = objDPersona.Consultar();
            int cantidad = lstClientes.Count;
            string numeroString = (cantidad + 1).ToString();
            int cantidadDigitos = numeroString.Count();
            int ceros = 8 - cantidadDigitos;
            for (int i = 0; i < ceros; i++)
            {
                numeroString = "0" + numeroString;
            }

            //concatenar el año + el consecutivo
            consecutivo = fecha.Year + numeroString;

            return consecutivo;
        }
    }
}
