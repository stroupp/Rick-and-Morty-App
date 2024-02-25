import React from 'react';
import styles from './Pagination.module.css';

const Pagination = ({ currentPage, totalPages, onPageChange }) => {
  const pages = new Array(totalPages).fill(null).map((_, index) => index + 1);

  return (
    <div className={styles.pagination}>
      {pages.map(page => (
        <button key={page}
                className={styles.pageButton}
                onClick={() => onPageChange(page)}
                disabled={currentPage === page}>
          {page}
        </button>
      ))}
    </div>
  );
};

export default Pagination;
