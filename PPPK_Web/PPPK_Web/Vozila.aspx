<%@ Page Title="Vozila" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Vozila.aspx.cs" Inherits="PPPK_Web.Vozila" %>

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
                    <asp:ListBox runat="server"
                        ID="lbVozila"
                        CssClass="form-control"
                        OnSelectedIndexChanged="lbVozila_SelectedIndexChanged"
                        AutoPostBack="true" Rows="10" />
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Detalji i uređivanje vozila</label>
                    <div>
                        <label class="style5">Marka: </label>
                        <asp:TextBox ID="txtMarkaUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Tip: </label>
                        <asp:TextBox ID="txtTipUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Godina proizvodnje: </label>
                        <asp:TextBox ID="txtGodinaProizvodnjeUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Stanje kilometara: </label>
                        <asp:TextBox ID="txtStanjeKilometaraUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="Spremi"
                            OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn" Text="Obriši"
                            OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Unos novog vozila</label>
                    <div>
                        <label class="style5">Marka: </label>
                        <asp:TextBox ID="txtMarka" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Tip: </label>
                        <asp:TextBox ID="txtTip" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Godina proizvodnje: </label>
                        <asp:TextBox ID="txtGodinaProizvodnje" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Stanje kilometara: </label>
                        <asp:TextBox ID="txtStanjeKilometara" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnDodaj" runat="server" CssClass="btn" Text="Dodaj"
                            OnClick="btnDodaj_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblInfo" runat="server" CssClass="info"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
