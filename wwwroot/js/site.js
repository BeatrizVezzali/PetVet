$(document).ready(
    function()
    {
       $("#frmAgendamento").submit(
         function(e)
         {
            e.preventDefault();
            Agendamento();
         }
       )
    }
 );
 
 function Agendamento()
 {
     let parametros = {
 
         Nome: $("#nome").val(),
         Telefone: $("#telefone").val(),
         Data: $("#data").val(),
         Animal: $("#animal").val(),
         Necessidade: $("#necessidade").val()
     };
 
     $.post("Home/Agendamento", parametros).done(
         function(data)
     {
         if(data.status == "Ok")
         {
            $("#frmAgendamento").after(data.mensagem)
            $("#frmAgendamento").hide();
         }
         else
         {
             alert(data.mensagem);
         }
     })
     .fail(function()
     {
       alert("Ocorreu um erro");
     }
     )
 };
 