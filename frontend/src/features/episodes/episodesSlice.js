// src/features/episodes/episodesSlice.js
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchEpisodes } from '../../api/episodesApi'; 

const initialState = {
  episodes: [],
  status: 'idle', // 'idle', 'loading', 'succeeded', 'failed'
  error: null,
};


export const fetchEpisodesAsync = createAsyncThunk(
    'episodes/fetchEpisodes',
    async (page) => {
      const response = await fetchEpisodes(page);
      return response.results; 
    }
  );

const episodesSlice = createSlice({
  name: 'episodes',
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(fetchEpisodesAsync.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(fetchEpisodesAsync.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.episodes = action.payload;
      })
      .addCase(fetchEpisodesAsync.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.error.message;
      });
  },
});

export default episodesSlice.reducer;
