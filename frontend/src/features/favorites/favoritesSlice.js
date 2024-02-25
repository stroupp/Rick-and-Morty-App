// src/features/favorites/favoritesSlice.js
import { createSlice } from '@reduxjs/toolkit';

export const favoritesSlice = createSlice({
  name: 'favorites',
  initialState: {
    characters: [],
  },
  reducers: {
    addFavorite: (state, action) => {
      const exists = state.characters.find((char) => char.id === action.payload.id);
      if (state.characters.length >= 10 && !exists) {
        alert("You can only add up to 10 favorite characters.");
        return;
      }
      if (!exists) {
        state.characters.push(action.payload);
      }
    },
    removeFavorite: (state, action) => {
      state.characters = state.characters.filter(character => character.id !== action.payload);
    },
  },
});

export const { addFavorite, removeFavorite } = favoritesSlice.actions;

export default favoritesSlice.reducer;
