import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchPostById, updatePost, createPost } from '../api/api';
import Modal from 'react-modal';
import '../css/CreateEditPost.css';

const CreateEditPost = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [post, setPost] = useState({ id: '', title: '', body: '' });
  const [error, setError] = useState('');
  const [modalIsOpen, setModalIsOpen] = useState(false);

  useEffect(() => {
    if (id) {
      fetchPostById(id).then((data) => setPost(data));
    }
  }, [id]);

  const validateId = async () => {
    try {
      await fetchPostById(post.id);
      setError('ID already exists!');
      return false;
    } catch (error) {
      setError('');
      return true;
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    let isValidId = true;

    if (!id) { // Only validate ID if it's a new post
      isValidId = await validateId();
    }

    if (isValidId) {
      if (id) {
        await updatePost(id, post);
      } else {
        await createPost(post);
      }
      setModalIsOpen(true);
    }
  };

  const closeModal = () => {
    setModalIsOpen(false);
    navigate('/posts');
  };

  return (
    <div className="form-container">
      <h1>{id ? 'Edit Post' : 'Create Post'}</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="ID"
          value={post.id}
          onChange={(e) => setPost({ ...post, id: e.target.value })}
          disabled={!!id} // Disable ID field when editing
        />
        <input
          type="text"
          placeholder="Title"
          value={post.title}
          onChange={(e) => setPost({ ...post, title: e.target.value })}
        />
        <textarea
          placeholder="Content"
          value={post.body}
          onChange={(e) => setPost({ ...post, body: e.target.value })}
        />
        {error && <p style={{ color: 'red' }}>{error}</p>}
        <button type="submit">{id ? 'Update' : 'Submit'}</button>
      </form>

      <Modal
        isOpen={modalIsOpen}
        onRequestClose={closeModal}
        contentLabel="Submit Success Modal"
        className="modal-container"
        overlayClassName="modal-overlay"
      >
        <div className="modal-content">
          <h2>Submission Successful!</h2>
          <p>Your post has been {id ? 'updated' : 'created'} successfully.</p>
          <button onClick={closeModal}>OK</button>
        </div>
      </Modal>
    </div>
  );
};

export default CreateEditPost;
