<%@ Page Title="Putni nalozi" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PutniNalozi.aspx.cs" Inherits="PPPK_Web.PutniNalozi" %>

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
                        ID="lbPutniNalozi"
                        CssClass="form-control"
                        OnSelectedIndexChanged="lbPutniNalozi_SelectedIndexChanged"
                        AutoPostBack="true" Rows="10" />
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Detalji i uređivanje putnih naloga</label>
                    <div>
                        <label class="style5">Vozač: </label><br />
                        <%--<asp:TextBox ID="txtVozacUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddVozacUpdate"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddVozacUpdate_SelectedIndexChanged"
                            runat="server" />
                    </div>
                    <div>
                        <label class="style5">Vozilo: </label><br />
                        <%--<asp:TextBox ID="txtVoziloUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddVoziloUpdate"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddVoziloUpdate_SelectedIndexChanged"
                            runat="server" />
                    </div>
                    <div>
                        <label class="style5">Datum: </label>
                        <asp:TextBox ID="txtDatumUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Tip: </label>
                        <asp:TextBox ID="txtTipUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Polazište: </label>
                        <asp:TextBox ID="txtKoordinataAUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Odredište: </label>
                        <asp:TextBox ID="txtKoordinataBUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Prijedeni kilometri: </label>
                        <asp:TextBox ID="txtKilometriUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Prosjecna brzina: </label>
                        <asp:TextBox ID="txtBrzinaUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Potroseno gorivo: </label>
                        <asp:TextBox ID="txtGorivoUpdate" Text="-" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="Spremi"
                            OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn" Text="Obriši"
                            OnClick="btnDelete_Click" /><br /><br />
                        <asp:Button ID="btnUpdateDAAB" runat="server" CssClass="btn" Text="Spremi DAAB"
                            OnClick="btnUpdateDAAB_Click" />
                        <asp:Button ID="btnDeleteDAAB" runat="server" CssClass="btn" Text="Obriši DAAB"
                            OnClick="btnDeleteDAAB_Click" />
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Unos novog putnog naloga</label>
                    <div>
                        <label class="style5">Vozač: </label><br />
                        <%--<asp:TextBox ID="txtVozac" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddVozac"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddVozac_SelectedIndexChanged"
                            runat="server" />
                    </div>
                    <div>
                        <label class="style5">Vozilo: </label><br />
                        <%--<asp:TextBox ID="txtVozilo" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddVozilo"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddVozilo_SelectedIndexChanged"
                            runat="server" />
                    </div>
                    <div>
                        <label class="style5">Datum: </label>
                        <asp:TextBox ID="txtDatum" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Polazište: </label>
                        <asp:TextBox ID="txtKoordinataA" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <label class="style5">Odredište: </label>
                        <asp:TextBox ID="txtKoordinataB" runat="server" CssClass="txt"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnDodaj" runat="server" CssClass="btn" Text="Dodaj"
                            OnClick="btnDodaj_Click" />
                        <asp:Button ID="btnDodajDAAB" runat="server" CssClass="btn" Text="Dodaj DAAB"
                            OnClick="btnDodajDAAB_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblInfo" runat="server" CssClass="info"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
