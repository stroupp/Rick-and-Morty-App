// src/App.js
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import EpisodePage from './pages/EpisodePage';
import CharacterPage from './pages/CharacterPage';
import FavoritesPage from './pages/FavoritesPage';

const App = () => {
  return (
    <Router>
      <div>
        {}
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/episode/:id" element={<EpisodePage />} />
          <Route path="/character/:characterId" element={<CharacterPage />} />
          <Route path="/favorites" element={<FavoritesPage />} />
          {}
        </Routes>
      </div>
    </Router>
  );
};

export default App;
