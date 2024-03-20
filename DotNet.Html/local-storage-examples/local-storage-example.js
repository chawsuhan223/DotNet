const dotnetT = 'DotNetT';

runBlog();
function runBlog() {
    createBlog('Test3', 'Test4', 'Test5');
}
function readBlog() {

}
function editBlog() {

}
function createBlog(name, address, description) {
    let lstBlogs = [];//Array
    let blogStr = localStorage.getItem(dotnetT);
    if (blogStr != null) {
        lstBlogs = JSON.parse(blogStr);
    }
    const blog = {
        Id: uuidv4(),
        Name: name,
        Address: address,
        Description: description
    }
    lstBlogs.push(blog);
    //let jsonStr = JSON.stringify(blog);
    let jsonStr = JSON.stringify(lstBlogs);
    localStorage.setItem(dotnetT, jsonStr);


}
function updateBlog() {

}
function deleteBlog() {

}
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}
