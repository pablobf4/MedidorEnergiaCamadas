using MedidorEnergia.Modelo;
using MedidorEnergia.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidorEnergia.DTO;

namespace MedidorEnergia.DAL
{
   public class UsuarioDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 
         public void Inserir(UsuarioDTO usuarioDTO) 
        {
            var  usuario = new Usuario();
             usuario.Email = usuarioDTO.Email;
             usuario.EmailConfirmed = usuarioDTO.EmailConfirmed;
             usuario.PasswordHash = usuarioDTO.PasswordHash;
             usuario.SecurityStamp = usuarioDTO.SecurityStamp;
             usuario.PhoneNumber = usuarioDTO.PhoneNumber;
             usuario.PhoneNumberConfirmed = usuarioDTO.PhoneNumberConfirmed;
             usuario.TwoFactorEnabled = usuarioDTO.TwoFactorEnabled;
             usuario.LockoutEndDateUtc = usuarioDTO.LockoutEndDateUtc;
             usuario.LockoutEnabled = usuarioDTO.LockoutEnabled;
             usuario.AccessFailedCount = usuarioDTO.AccessFailedCount;
             usuario.UserName = usuarioDTO.UserName;

            db.Usuario.Add(usuario);
            db.SaveChanges();
        }
        public List<UsuarioDTO> Lista() 
    {
        var resultado = new List<UsuarioDTO>();
        var lista = db.Usuario.ToList();
        foreach (var t in lista )
        {
            var usuarioDTO = new UsuarioDTO();
            usuarioDTO.Email = t.Email;
            usuarioDTO.EmailConfirmed = t.EmailConfirmed;
            usuarioDTO.PasswordHash = t.PasswordHash;
            usuarioDTO.SecurityStamp = t.SecurityStamp;
            usuarioDTO.PhoneNumber = t.PhoneNumber;
            usuarioDTO.PhoneNumberConfirmed = t.PhoneNumberConfirmed;
            usuarioDTO.TwoFactorEnabled = t.TwoFactorEnabled;
            usuarioDTO.LockoutEndDateUtc = t.LockoutEndDateUtc;
            usuarioDTO.LockoutEnabled = t.LockoutEnabled;
            usuarioDTO.AccessFailedCount = t.AccessFailedCount;
            usuarioDTO.UserName = t.UserName;
            resultado.Add(usuarioDTO);
        }
        return resultado;    
  
            
        }
        public void Deletar() { }
        public void Atualizar() { }
      
    }

    }

