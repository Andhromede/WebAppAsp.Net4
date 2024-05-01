# ApplicationWebAspDotNet3

Ce projet est une application web de réservation construite avec ASP.NET Web Forms et utilisant MySQL, Bootstrap, et jQuery/Ajax. Elle permet aux utilisateurs de s'inscrire, de se connecter, et de réserver des services. Le projet inclut également une validation avancée du côté serveur et client pour s'assurer que les logins et les emails sont uniques dans la base de données.


## Prérequis :

Ce projet nécessite les éléments suivants :

- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [WampServer](http://www.wampserver.com/) pour MySQL
- [Visual Studio](https://visualstudio.microsoft.com/) **ATTENTION** : Par défaut, Visual Studio 2022 ne supporte pas directement .NET Framework 4.8 pour les projets Web Forms. Il est donc nécéssaire d'activer cette compatibilité en installant les modules nécessaires. 
- Un navigateur web moderne capable de supporter JavaScript et AJAX.


### Installation des modules Visual Studio pour .NET Framework 4.8 :

1. Lancez l'installateur de Visual Studio.
2. Choisissez "Modifier" sur l'installation existante de Visual Studio 2022.
3. Dans l'installateur, naviguez à la section "Composants individuels".
4. Cherchez et cochez les options suivantes:
   - **.NET Framework 4.8 SDK**
   - **.NET Framework 4.8 targeting pack**
   - **Développement ASP.NET et web**
   Ce dernier inclut les outils nécessaires pour le développement de Web Forms.


## Installation

Pour cloner et exécuter ce projet localement, suivez les étapes ci-dessous :

(avec Git bash)
git clone https://github.com/Andhromede/ApplicationWebAspDotNet3.git
cd ApplicationWebAspDotNet3

# Instructions pour la configuration de la base de données et autres dépendances



## Fonctionnalités :

- Inscription et connexion des utilisateurs (avec vérification du formulaire côté front et côté back).
- Validation de l'unicité du login et de l'email.
- Vérification en temps réel des champs via AJAX.


## Auteur :

- **Nath** - *Travail Initial* - [Andhromede](https://github.com/Andhromede)

Ce projet est licencié sous la licence MIT - voir le fichier LICENSE.md pour plus de détails.