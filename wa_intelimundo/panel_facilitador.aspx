<%@ Page Title="" Language="C#" MasterPageFile="~/intelimundo.Master" AutoEventWireup="true" CodeBehind="panel_facilitador.aspx.cs" Inherits="wa_intelimundo.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <br />
            <div class="containes">
                <div class="form-group">
                    <div class="panel panel-default" id="div_pnl" runat="server">
                        <div class="panel-heading">

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
   
</asp:Content>
