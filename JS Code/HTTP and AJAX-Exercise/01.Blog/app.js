function attachEvents() {
    const loadBtn = document.getElementById('btnLoadPosts')
    const viewBtn = document.getElementById('btnViewPost')
    const postsField = document.getElementById('posts')

    let posts = []

    const postsURL = 'http://localhost:3030/jsonstore/blog/posts'
    const commentsURL = 'http://localhost:3030/jsonstore/blog/comments'

    loadBtn.addEventListener('click', () => {
        fetch(postsURL)
            .then(res => res.json())
            .then(postsData => {
                for (const key in postsData) {
                    const option = document.createElement('option')
                    option.textContent = postsData[key].title
                    postsField.appendChild(option)

                    posts.push(postsData[key])

                }
                console.log(posts)
            })
    })

    viewBtn.addEventListener('click', () => {
        fetch(commentsURL)
            .then(res => res.json())
            .then(commentsData => {
                const selectedIndex = postsField.options.selectedIndex

                const selectedOption = posts[selectedIndex]
                const selectedOptionID = posts[selectedIndex].id

                for (const key in commentsData) {

                    if (commentsData[key].postId===selectedOptionID) {
                        let title=document.getElementById('post-title')
                        title.textContent=selectedOption.title

                        let body=document.getElementById('post-body')
                        body.textContent=selectedOption.body

                        let commentsLi=document.createElement('li')
                        commentsLi.textContent= commentsData[key].text
                        let postsComments=document.getElementById('post-comments')
                        postsComments.appendChild(commentsLi)
                    }
                }



            })

    })
}

attachEvents();