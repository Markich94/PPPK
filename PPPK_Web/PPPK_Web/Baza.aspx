<%@ Page Title="Baza" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Baza.aspx.cs" Inherits="PPPK_Web.Baza" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .style1 {
            width: 400px;
        }

        .style2 {
            width: 110px;
        }

        .style3 {
            width: 180px;
        }

        .style4 {
            width: 100%;
        }

        .style5 {
            width: 250px;
        }

        .style6 {
            width: 170px;
        }
        .btn {
            background-color: lightblue;
        }
    </style>

    <h2><%: Title %></h2>
    <div class="jumbotron">
        <hr />
        <div class="row">
            <div class="col-sm-4">
                <div class="form-group">
                    <div>
                        <asp:Button ID="btnInicijaliziraj" runat="server" CssClass="btn" Text="Inicijaliziraj bazu"
                            OnClick="btnInicijaliziraj_Click" />
                        <asp:Button ID="btnOcisti" runat="server" CssClass="btn" Text="Očisti bazu"
                            OnClick="btnOcisti_Click" /><br /><br />
                    </div>
                    <div>
                        <asp:Button ID="btnExportXml" runat="server" CssClass="btn" Text="Export u XML"
                            OnClick="btnExportXml_Click" />
                        <asp:Button ID="btnImportXml" runat="server" CssClass="btn" Text="Import iz XML-a"
                            OnClick="btnImportXml_Click" /><br /><br />
                    </div>
                    <div>
                        <asp:Button ID="btnBackup" runat="server" CssClass="btn" Text="Backup"
                            OnClick="btnBackup_Click" />
                        <asp:Button ID="btnRestore" runat="server" CssClass="btn" Text="Restore"
                            OnClick="btnRestore_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblInfo" runat="server" CssClass="info"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
