//fake api json placeholder is used for demonstration purpose
import React, {useState,useEffect} from 'react';
import axios from 'axios';
import Post from './Post';

const AllPosts = ()=>{
    const [posts, setPosts] = useState([]);
    

    useEffect(()=>{
        axios.get("https://jsonplaceholder.typicode.com/posts")
        .then(resp=>{
            console.log(resp.data);
            setPosts(resp.data);
        }).catch(err=>{
            console.log(err);
        });
    },[]);

    return(
        /*<div>
            <table>
                <thead>
                    <tr><th>Id</th><th>Name</th></tr>
                </thead>
                <tbody>
                {
                    posts.map(post=>(
                        <tr key={post.id}>
                            <td>{post.id}</td>
                            <td>{post.title}</td>
                        </tr>
                    ))
                }
                </tbody>
            </table>
        </div>*/
        <div>
            {
                posts.map(post=>(
                  <Post userId={post.userId} title={post.title} key={post.id}/>
                ))
            }
        </div>
    )

}

export default AllPosts;