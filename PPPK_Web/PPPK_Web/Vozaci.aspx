<%@ Page Title="Vozači" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Vozaci.aspx.cs" Inherits="PPPK_Web.Vozaci" %>

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
                        ID="lbVozaci"
                        CssClass="form-control"
                        OnSelectedIndexChanged="lbVozaci_SelectedIndexChanged"
                        AutoPostBack="true" Rows="10" />
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Detalji i uređivanje vozača</label>
                    <div>
                        <label class="style5">Ime: </label>
                        <asp:TextBox ID="txtImeUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Prezime: </label>
                        <asp:TextBox ID="txtPrezimeUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Broj mobitela: </label>
                        <asp:TextBox ID="txtBrojMobitelaUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Broj vozačke: </label>
                        <asp:TextBox ID="txtBrojVozackeUpdate" Text="-" runat="server" CssClass="txt"
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
                    <label>Unos novog vozača</label>
                    <div>
                        <label class="style5">Ime: </label>
                        <asp:TextBox ID="txtIme" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Prezime: </label>
                        <asp:TextBox ID="txtPrezime" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Broj mobitela: </label>
                        <asp:TextBox ID="txtBrojMobitela" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Broj vozačke: </label>
                        <asp:TextBox ID="txtBrojVozacke" runat="server" CssClass="txt"
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
