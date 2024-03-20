const dotnetT = 'DotNetT';

runBlog();
function runBlog() {
createBlog('Test3','Test4','Test5');
}
function readBlog() {

}
function editBlog() {

}
function createBlog(name, address, description) {
    const blog = {
        Name: name,
        Address: address,
        Description: description
    }
    let jsonStr=JSON.stringify(blog);

    localStorage.setItem(dotnetT,jsonStr);


}
function updateBlog() {

}
function deleteBlog() {

}

