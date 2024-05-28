import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { fetchPostById, updatePost, createPost } from '../api/api';
import axios from 'axios';
import '../css/PostsBooks.css';

const PostsBooks = () => {
  const [posts, setPosts] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    fetchPosts();
  }, []);

  const fetchPosts = async () => {
    try {
      const response = await axios.get('http://localhost:5000/posts');
      setPosts(response.data);
    } catch (error) {
      console.error('Error fetching posts:', error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`http://localhost:5000/posts/${id}`);
      fetchPosts();
    } catch (error) {
      console.error('Error deleting post:', error);
    }
  };

  const filteredPosts = posts.filter(post =>
    post.title.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="posts-books">
      <div className="section-header">
        <h1 className="postbook-header">Posts/Books</h1>
        <div className="search-bar">
          <input
            type="text"
            placeholder="Search by title"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
        <Link to="/create-post" className="create-post-button">Create Post</Link>
      </div>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Description</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {filteredPosts.map(post => (
            <tr key={post.id} className="post">
              <td>{post.id}</td>
              <td>{post.title}</td>
              <td>{post.body}</td> {/* Use 'body' for description */}
              <td>
                <Link to={`/posts/${post.id}`} className="action-button detail-button">Detail</Link>
                <Link to={`/edit-post/${post.id}`} className="action-button edit-button">Edit</Link>
                <button className="action-button delete-button" onClick={() => handleDelete(post.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default PostsBooks;
