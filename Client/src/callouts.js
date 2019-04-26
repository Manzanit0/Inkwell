export const fetchPostsWithBlurb = async () => {
  try {
    const posts = await (await fetch("https://localhost:8081/api/posts")).json();
    return posts.map(post => {
      post.blurb = post.content.substring(0, 120) + "...";
      return post;
    });
  }
  catch(error) {
    console.log(error);
  }
};

export const fetchPost = async (title) => {
  try {
    const posts = await (await fetch("https://localhost:8081/api/posts")).json();
    return posts.filter(post => post.title === title)[0]; // Upon several, pick the first.
  }
  catch(error) {
    console.log(error);
  }
};
