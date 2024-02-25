import React, { useEffect, useState } from 'react';
import { fetchEpisodes, fetchEpisodesCountAndPages } from '../api/rickAndMortyApi';
import NavBar from '../components/NavBar';
import EpisodeCard from '../components/EpisodeCard';
import PaginationComponent from '../components/Pagination';
import styles from './HomePage.module.css';

const HomePage = () => {
  const [episodes, setEpisodes] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [episodesPerPage, setEpisodesPerPage] = useState(0);
  const [search, setSearch] = useState('');
  const [error, setError] = useState('');

  useEffect(() => {
    const loadEpisodesData = async () => {
      try {
        const episodesData = await fetchEpisodes(currentPage); 
        const { count, pages } = await fetchEpisodesCountAndPages();
        if (episodesData && count && pages) {
          setEpisodes(episodesData);
          setTotalPages(pages);
          setEpisodesPerPage(Math.ceil(count / pages));
          setError(''); 
        } else {
          setError('No episodes list available.');
        }
      } catch (error) {
        console.error('Failed to load episodes data:', error);
        setError('No episodes list available.');
      }
    };

    loadEpisodesData();
  }, [currentPage]);

  const indexOfLastEpisode = currentPage * episodesPerPage;
  const indexOfFirstEpisode = indexOfLastEpisode - episodesPerPage;
  const currentEpisodes = episodes.slice(indexOfFirstEpisode, indexOfLastEpisode);

  const filteredEpisodes = currentEpisodes.filter(episode => {
    const nameMatch = episode.name?.toLowerCase().includes(search.toLowerCase());
    const characterMatch = episode.characters?.some(character => character.name?.toLowerCase().includes(search.toLowerCase()));
    return nameMatch || characterMatch;
  });

  return (
    <div className={styles.homePage}>
      <NavBar />
      <div className={styles.searchContainer}>
        <input
          type="text"
          className={styles.searchInput}
          placeholder="Search episodes or characters..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
      </div>
      {error ? (
        <p>{error}</p>
      ) : (
        <div className={styles.episodeList}>
          {filteredEpisodes.length > 0 ? (
            filteredEpisodes.map(episode => <EpisodeCard key={episode.id} episode={episode} />)
          ) : (
            <p>No episodes found.</p>
          )}
        </div>
      )}
      {!error && (
        <PaginationComponent currentPage={currentPage} totalPages={totalPages} onPageChange={page => setCurrentPage(page)} />
      )}
    </div>
  );
};

export default HomePage;
