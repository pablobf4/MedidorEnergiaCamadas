using MedidorEnergia.DTO;
using MedidorEnergia.Modelo;
using MedidorEnergia.Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorEnergia.DAL
{
    public class MedidaDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();  
        public void Inserir(MedidaDTO medidaDTO) 
        {
            var  medida = new Medida();
            medida.Potencia = medidaDTO.Potencia;
            medida.Corrente = medidaDTO.Corrente;
            medida.Horario = medidaDTO.Horario;
            medida.IDObjeto = medidaDTO.IDObjeto;
           
            db.Medidas.Add(medida);
            db.SaveChanges();
        }
        public List<MedidaDTO> Lista() 
    {
        var resultado = new List<MedidaDTO>();
        var lista = db.Medidas.ToList();
        foreach (var t in lista )
        {
            var medidaDTO = new MedidaDTO();
            medidaDTO.Corrente = t.Corrente;
            medidaDTO.Potencia = t.Potencia;
            medidaDTO.IDObjeto = t.IDObjeto;
            medidaDTO.Horario = t.Horario;
           
            resultado.Add(medidaDTO);
        }
        return resultado;    
  
            
        }
        public void Deletar() { }
        public void Atualizar() { }
      
    }
}
