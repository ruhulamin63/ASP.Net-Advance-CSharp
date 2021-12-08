import React from 'react';

const Post =(props)=>{

    //const {title,userId} = props;

    const PostStyle={
        backgroundColor: "#BA9987",
        fontFamily:"consolas",
        color:"white",
        width:"400px",
        padding:"10px",
        
        
    };

    return (
        <div style={PostStyle}>
            <span>{props.userId}</span>
            <p>{props.title}</p>
        </div>
    )
}

export default Post;