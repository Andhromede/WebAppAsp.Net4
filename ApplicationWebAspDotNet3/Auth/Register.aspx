<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ApplicationWebAspDotNet3.Register" %>


<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vh-100">
        <div class="container-fluid h-custom">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-md-9 col-lg-6 col-xl-5">
                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp" class="img-fluid" alt="Sample image" />
                </div>

                <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">

                    <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                        <p class="lead fw-normal mb-0 me-3">Inscription</p>
                    </div>

                    <!-- Login input -->
                    <div class="form-outline mb-4">
                        <asp:Label AssociatedControlID="Login" runat="server" class="form-label">Login :</asp:Label>
                        <asp:TextBox ID="Login" runat="server" class="form-control form-control-lg" ClientIDMode="Static"></asp:TextBox>
                        <div class="text-danger font-weight-bold" id="LoginMatch"></div>
                    </div>

                    <!-- Email input -->
                    <div class="form-outline mb-4">
                        <asp:Label AssociatedControlID="Email" runat="server" class="form-label">Email :</asp:Label>
                        <asp:TextBox ID="Email" runat="server" class="form-control form-control-lg" ClientIDMode="Static"></asp:TextBox>
                        <div class="text-danger font-weight-bold" id="EmailMatch"></div>
                    </div>

                    <!-- Password input -->
                    <div class="form-outline mb-3">
                        <label for="Password" class="form-label">Mot de passe :</label>
                        <asp:TextBox ID="Password" TextMode="Password" runat="server" class="form-control form-control-lg" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <!-- Confirm Password input -->
                    <div class="form-outline mb-3">
                        <label for="ConfirmPassword" class="form-label">Confirmation de Mot de passe :</label>
                        <asp:TextBox ID="ConfirmPassword" TextMode="Password" runat="server" class="form-control form-control-lg" ClientIDMode="Static"></asp:TextBox>
                        <div class="text-danger font-weight-bold" id="passwordMatch"></div>
                    </div>

                    <div class="text-center text-lg-start mt-4 pt-2">

                        <asp:Button
                            type="button"
                            class="btn btn-primary btn-lg"
                            ID="RegisterButton"
                            runat="server"
                            Text="Inscription"
                            OnClick="RegisterButton_Click"
                            Style="padding-left: 2.5rem; padding-right: 2.5rem;" 
                            ClientIDMode="Static" 
                            disabled="disabled"/>

                        <p class="small fw-bold mt-2 pt-1 mb-0">
                            Déjà Inscrit ?
                            <a class="link-danger" runat="server" href="~/Auth/Login.aspx">Connexion</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>