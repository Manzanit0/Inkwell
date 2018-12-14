export const fetchPostsWithBlurb = async () => {
  try {
    const posts = await (await fetch("https://localhost:5001/api/posts")).json();
    return posts.map(post => {
      post.blurb = post.content.substring(0, 120) + "...";
      return post;
    });
  }
  catch(error) {
    console.log(error);
  }
};
