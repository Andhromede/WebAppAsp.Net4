# ApplicationWebAspDotNet3

Ce projet est une application web de réservation construite avec ASP.NET Web Forms et utilisant MySQL, Bootstrap, et jQuery/Ajax. Elle permet aux utilisateurs de s'inscrire, de se connecter, et de réserver des services. Le projet inclut également une validation avancée du côté serveur et client pour s'assurer que les logins et les emails sont uniques dans la base de données.


## Prérequis :

Ce projet nécessite les éléments suivants :

- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [WampServer](http://www.wampserver.com/) pour MySQL
- [Visual Studio](https://visualstudio.microsoft.com/) **ATTENTION** : Par défaut, Visual Studio 2022 ne supporte pas directement .NET Framework 4.8 pour les projets Web Forms. Il est donc nécéssaire d'activer cette compatibilité en installant les modules nécessaires. 
- Un navigateur web moderne capable de supporter JavaScript et AJAX.


## Installation

Pour cloner et exécuter ce projet localement, suivez les étapes ci-dessous :

(avec Git bash)
<br>
git clone https://github.com/Andhromede/ApplicationWebAspDotNet3.git
<br>
cd ApplicationWebAspDotNet3


### Installation des modules Visual Studio pour .NET Framework 4.8 :

1. Lancez l'installateur de Visual Studio.
2. Choisissez "Modifier" sur l'installation existante de Visual Studio 2022.
3. Dans l'installateur, naviguez à la section "Composants individuels".
4. Cherchez et cochez les options suivantes:
   - **.NET Framework 4.8 SDK**
   - **.NET Framework 4.8 targeting pack**
   - **Développement ASP.NET et web**
   Ce dernier inclut les outils nécessaires pour le développement de Web Forms.


# Instructions pour la configuration de la base de données et autres dépendances

Voici le sript SQL générant la base de données : 

```sql
CREATE TABLE Role(
   Id_Role INT AUTO_INCREMENT,
   name VARCHAR(10) NOT NULL,
   is_active BOOLEAN NOT NULL DEFAULT TRUE,
   PRIMARY KEY(Id_Role),
   UNIQUE(name)
);

CREATE TABLE lodging(
   Id_lodging INT AUTO_INCREMENT,
   name VARCHAR(50) NOT NULL,
   description TEXT NOT NULL,
   nbr_deb1 INT NOT NULL,
   nbr_bed2 INT NOT NULL,
   price DECIMAL(6,2) NOT NULL,
   is_active BOOLEAN NOT NULL DEFAULT TRUE,
   PRIMARY KEY(Id_lodging)
);

CREATE TABLE Picture(
   Id_Picture INT AUTO_INCREMENT,
   name VARCHAR(150) NOT NULL,
   path VARCHAR(255) NOT NULL,
   is_main BOOLEAN NOT NULL,
   is_active BOOLEAN NOT NULL DEFAULT TRUE,
   Id_lodging INT NOT NULL,
   PRIMARY KEY(Id_Picture),
   FOREIGN KEY(Id_lodging) REFERENCES lodging(Id_lodging)
);

CREATE TABLE Status(
   Id_Status INT AUTO_INCREMENT,
   name VARCHAR(20) NOT NULL,
   is_active BOOLEAN NOT NULL DEFAULT TRUE,
   PRIMARY KEY(Id_Status),
   UNIQUE(name)
);

CREATE TABLE Users(
   Id_Users INT AUTO_INCREMENT,
   login VARCHAR(50) NOT NULL,
   password VARCHAR(255) NOT NULL,
   email VARCHAR(100) NOT NULL,
   is_active BOOLEAN NOT NULL DEFAULT TRUE,
   Id_Role INT NOT NULL,
   PRIMARY KEY(Id_Users),
   UNIQUE(login),
   UNIQUE(email),
   FOREIGN KEY(Id_Role) REFERENCES Role(Id_Role)
);

CREATE TABLE Booking(
   Id_Booking INT AUTO_INCREMENT,
   start_date DATE NOT NULL,
   end_date DATE NOT NULL,
   booking_date DATETIME NOT NULL,
   payment_date DATETIME,
   status VARCHAR(50),
   nbr_persons INT NOT NULL,
   total_price DECIMAL(6,2) NOT NULL,
   is_active BOOLEAN NOT NULL DEFAULT TRUE,
   Id_Users INT NOT NULL,
   PRIMARY KEY(Id_Booking),
   FOREIGN KEY(Id_Users) REFERENCES Users(Id_Users)
);

CREATE TABLE Booking_Lodging(
   Id_Booking INT,
   Id_lodging INT,
   PRIMARY KEY(Id_Booking, Id_lodging),
   FOREIGN KEY(Id_Booking) REFERENCES Booking(Id_Booking),
   FOREIGN KEY(Id_lodging) REFERENCES lodging(Id_lodging)
);

CREATE TABLE Status_booking(
   Id_Booking INT,
   Id_Status INT,
   date_status DATETIME NOT NULL,
   PRIMARY KEY(Id_Booking, Id_Status),
   FOREIGN KEY(Id_Booking) REFERENCES Booking(Id_Booking),
   FOREIGN KEY(Id_Status) REFERENCES Status(Id_Status)
);
```

## Fonctionnalités :

- Inscription et connexion des utilisateurs (avec vérification du formulaire côté front et côté back).
- Validation de l'unicité du login et de l'email.
- Vérification en temps réel des champs via AJAX.


## Auteur :

- **Nath** - *Travail Initial* - [Andhromede](https://github.com/Andhromede)

Ce projet est licencié sous la licence MIT - voir le fichier LICENSE.md pour plus de détails.