import React, { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { fetchPostById } from '../api/api';
import '../css/PostDetail.css'; // Kết nối tệp CSS vào đây

const PostDetail = () => {
  const { id } = useParams();
  const [post, setPost] = useState({});

  useEffect(() => {
    const fetchPost = async () => {
      try {
        const data = await fetchPostById(id);
        setPost(data);
      } catch (error) {
        console.error('Error fetching post:', error);
      }
    };
    fetchPost();
  }, [id]);

  return (
    <div className="post-detail"> {}
      <h1>Post Detail with ID: {post.id}</h1>
      <h2>{post.title}</h2>
      <p>{post.body}</p>
      <Link className="back-link" to="/posts">Back to Posts</Link>
    </div>
  );
};

export default PostDetail;
