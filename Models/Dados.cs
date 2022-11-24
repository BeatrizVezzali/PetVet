using System;

namespace PetVet_MVC.Models
{
    public static class Dados{
    
     public static Agenda AgendaAtual { get; set;}
      static Dados()
      {
          AgendaAtual = new Agenda();
      }
    }
}
    
        