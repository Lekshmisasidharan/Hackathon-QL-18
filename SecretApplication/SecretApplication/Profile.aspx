<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SecretApplication.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div id="welcome-user" class="container-fluid justify-content-center">
    <div class="row">
        <h3>Hello
        <asp:Label ID="lblProfileName" runat="server" Text=""></asp:Label>
        , Please choose one of the options below.</h3>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <asp:Button ID="btnVanpool" runat="server" Text="Find A Ride" class="btn btn-primary btn-lg container h-100 d-flex justify-content-center" OnClick="btnVanpool_Click" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <asp:Button ID="btnVanpoolPost" runat="server" Text="Organize A Ride" class="btn btn-primary btn-lg container h-100 d-flex justify-content-center" OnClick="btnVanpoolPost_Click" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <asp:Button ID="btnseelist" runat="server" Text="Open Vanpool/Carpool" class="btn btn-primary btn-lg container h-100 d-flex justify-content-center" OnClick="btnOpenVan_Click" />
            </div>
        </div>
    </div>
   </div>
</asp:Content>
