# Rick and Morty API Backend Project

This project is a .NET backend application that serves as an intermediary to fetch and process data from the Rick and Morty API.

## Prerequisites

- .NET 8.0 SDK 


### Clone Repository

To clone the repository, run the following command in your terminal:

```bash
git clone https://github.com/stroupp/RickAndMortyApp.git
```
### Installing Dependencies
```bash
dotnet restore
```
### How to run?

Navigate to to backend file from the root file with
```bash
cd backend
cd RickAndMortyAPI.API
dotnet run
```
### API Endpoints

The following endpoints are available:

GET /rickandmorty/characters - Retrieves a list of characters.
GET /rickandmorty/episodes - Retrieves a list of episodes.
GET /rickandmorty/characters/{id} - Retrieves a character by ID.
GET /rickandmorty/episodes/{id} - Retrieves an episode by ID.
GET /rickandmorty/episodes/count - Retrieves the count and pages of episodes.




# Rick and Morty API Frontend Project

This project is a React-based web application that allows users to explore characters and episodes from the "Rick and Morty" series. It provides detailed views of characters, including their status, species, and last known location, as well as a comprehensive list of episodes. Users can also mark characters as favorites and view a list of their selected favorites.

## Features

- Browse all "Rick and Morty" episodes and characters
- View detailed information about each character
- Add characters to a favorites list
- Pagination for episodes
- Search functionality for episodes and characters

## Prerequisites
- npm
- node.js

- ### Clone Repository

To clone the repository, run the following command in your terminal:

```bash
git clone https://github.com/stroupp/RickAndMortyApp.git
```

## How to run

Navigate to frontend file from the root file with
```bash
cd frontend
npm install
npm start
```

## Page Info
-The homepage displays a list of episodes. User can click on an episode to view detailed information about the episode and its characters.
-you can use the search bar at the top to filter episodes or characters by name.
-user can click on a character to view the detailed information about them. From their detailed view, you can add characters to the favorites.
-user can access anytime to the favorites by clicking "Favorites" link in the navigation bar.

## Pages

### Homepage

The homepage displays a list of episodes and offers pagination to navigate through them.

![Homepage](https://imgur.com/Ie14OTW.jpg "Homepage of Rick and Morty Character Explorer")

### Character Page

View detailed information about characters, including their status, species, and last known location.

![Character Page](https://imgur.com/Ib6odvn.jpg "Character Page")

### Episode Page

Each episode's page provides details about the episode, including its name, air date, and characters featured in it.

![Episode Page](https://imgur.com/QqDfuMD.jpg "Episode Page")

### Favorites Page

Users can view and manage their favorite characters on this page.

![Favorites Page](https://imgur.com/kcs5dCD.jpg "Favorites Page")




