<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApplicationWebAspDotNet3.Auth.Login" %>


<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vh-100">
        <div class="container-fluid h-custom">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-md-9 col-lg-6 col-xl-5">
                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp" class="img-fluid" alt="Sample image" />
                </div>

                <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">

                    <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                        <p class="lead fw-normal mb-0 me-3">Connexion</p>
                    </div>

                    <!-- Login input -->
                    <div class="form-outline mb-4">
                        <asp:Label AssociatedControlID="TxtLogin" runat="server" class="form-label">Login :</asp:Label>
                        <asp:TextBox ID="TxtLogin" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>

                    <!-- Password input -->
                    <div class="form-outline mb-3">
                        <label for="TxtPassword" class="form-label">Mot de passe :</label>
                        <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>

                    <div class="d-flex justify-content-between align-items-center">
                        <a href="#!" class="text-body">Mots de passe perdu ?</a>
                    </div>

                    <div class="text-center text-lg-start mt-4 pt-2">

                        <asp:Button
                            type="button"
                            class="btn btn-primary btn-lg"
                            ID="LoginButton"
                            runat="server"
                            Text="Connexion"
                            OnClick="LoginButton_Click"
                            Style="padding-left: 2.5rem; padding-right: 2.5rem;" />

                        <p class="small fw-bold mt-2 pt-1 mb-0">
                            Pas encore Inscrit ?
                            <a class="link-danger" runat="server" href="~/Auth/Register.aspx">Inscription</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
