// src/api/rickAndMortyApi.js
import axios from 'axios';

// Adjust the base URL to point to your local API
const API_BASE_URL = 'http://localhost:5227/rickandmorty';
const API_KEY = 'exampleapikey'; 

const axiosInstance = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
    'X-API-KEY': API_KEY 
  }
});

export const fetchEpisodes = async (page = 1) => {
  try {
    const response = await axiosInstance.get(`/episodes?page=${page}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching episodes:', error);
    throw error;
  }
};

export const fetchEpisodesCountAndPages = async () => {
  try {
    const response = await axiosInstance.get(`/episodes/count`);
    console.log(response.data);
    return response.data;
  } catch (error) {
    console.error('Error fetching episodes count and pages:', error);
    throw error;
  }
};


export const fetchCharacterDetails = async (characterId) => {
  try {
    const response = await axiosInstance.get(`/characters/${characterId}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching character details for ID ${characterId}:`, error);
    throw error;
  }
};

export const fetchCharacters = async (characterIds = []) => {
  try {
    const ids = characterIds.join(',');
    const response = await axiosInstance.get(`/characters/${ids}`);
    return Array.isArray(response.data) ? response.data : [response.data];
  } catch (error) {
    console.error('Error fetching characters:', error);
    throw error;
  }
};

export const fetchEpisodeDetails = async (episodeId) => {
  try {
    const episodeResponse = await axiosInstance.get(`/episodes/${episodeId}`);
    const episode = episodeResponse.data;

    const characterResponses = await Promise.all(
      episode.characters.map(characterId =>
        axiosInstance.get(`/characters/${characterId}`)
      )
    );
    const characters = characterResponses.map(response => response.data);

    return { ...episode, characters }; 
  } catch (error) {
    console.error(`Error fetching episode details for ID ${episodeId}:`, error);
    throw error;
  }
};

export const fetchCharacterById = async (id) => {
  try {
    const response = await axiosInstance.get(`/characters/${id}`);
    if (response.status !== 200) {
      throw new Error('Failed to fetch character');
    }
    return response.data;
  } catch (error) {
    throw new Error('Failed to fetch character');
  }
};
