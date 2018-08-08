<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SecretApplication.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="contactus" class="container h-100 d-flex justify-content-center">
        <div id="contact-form" class="col-md-4">
            <h2 class="text-center">Contact</h2>
            <div class="form-group">
                <label for="name">Name</label>
                <asp:TextBox ID="txtboxname" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Enter Name"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="email">Email</label>
                <asp:TextBox ID="txtboxemail" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Enter Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="message">Message</label>
                <textarea id="TextArea1" cols="20" rows="2" runat="server"></textarea>
<%--                <asp:TextBox ID="txtboxmessage" runat="server" class="form-control" placeholder="Message"></asp:TextBox>--%>
            </div>
            <div class="form-group">
                <asp:Button ID="btnmsgSubmit" runat="server" Text="Submit" class="btn btn-primary btn-lg" OnClick="btnsubmitMessagePost_Click" />
            </div>
        </div>
    </div>

    <%--<div id="contact-us" class="container">
      <div class="row">
          <section class="col-sm-4">
          </section>
        <section id="hours" class="col-sm-4">
          <span>Hours:</span><br>
          Mon-Fri: 7:00am - 10:00pm<br>
          Fri: 7:00am - 8:00pm<br>
          <hr class="visible-xs">
        </section>
        <section id="address" class="col-sm-4">
          <span>Address:</span><br>
          One Woodward<br>
          Detroit
          <hr class="visible-xs">
        </section>
      </div>
        </div>--%>
</asp:Content>
