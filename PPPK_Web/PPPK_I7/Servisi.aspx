<%@ Page Title="Servisi" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Servisi.aspx.cs" Inherits="PPPK_I7.Servisi" %>

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
                        ID="lbServisiVozila"
                        CssClass="form-control"
                        OnSelectedIndexChanged="lbServisiVozila_SelectedIndexChanged"
                        AutoPostBack="true" Rows="10" />
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Detalji servisa</label>
                    <div>
                        <label class="style5">Vozilo: </label>
                        <asp:TextBox ID="txtVoziloUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Stanje kilometara: </label>
                        <asp:TextBox ID="txtStanjeKilometaraUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Napomena: </label>
                        <asp:TextBox ID="txtNapomenaUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Idući servis: </label>
                        <asp:TextBox ID="txtIduciServisUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Cijena: </label>
                        <asp:TextBox ID="txtCijenaUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="Spremi"
                            OnClick="btnUpdate_Click" />
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Unos novog servisa</label>
                    <div>
                        <label class="style5">Vozilo: </label>
                        <asp:DropDownList ID="ddVozilo"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddVozilo_SelectedIndexChanged"
                            runat="server" />
                    </div>
                    <div>
                        <label class="style5">Stanje kilometara: </label>
                        <asp:TextBox ID="txtStanjeKilometara" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Napomena: </label>
                        <asp:TextBox ID="txtNapomena" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Idući servis: </label>
                        <asp:TextBox ID="txtIduciServis" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Cijena: </label>
                        <asp:TextBox ID="txtCijena" Text="-" runat="server" CssClass="txt"
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