<%@ Page Title="" Language="C#" MasterPageFile="~/Menu_Encuesta.Master" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen_3_Eduardo_Espinoza.Encuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
<h1>VOTACIONES</h1>    
</div>
       <div class="container text-center">
    Nombre: <asp:TextBox ID="TxtNombre" class="form-control" runat="server"></asp:TextBox>
    Fecha de nacimiento: <asp:TextBox ID="TxtNacimiento" class="form-control" runat="server"></asp:TextBox>
    Correo electronico: <asp:TextBox ID="TextCorreo" class="form-control" runat="server"></asp:TextBox>
    Partido por votar: <asp:DropDownList ID="DDLPartido" class="form-control" runat="server"></asp:DropDownList>
</div>
 <div class="container text-center">
 <asp:Button ID="BtnAgregar" class="btn btn-success" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" />
</div>
</asp:Content>
