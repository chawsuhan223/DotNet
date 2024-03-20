const dotnetT = 'DotNetT';
//must use 'let' DOn't use 'var'
runBlog();
function runBlog() {
    //readBlog();
    //createBlog('Test3', 'Test4', 'Test5');
    editBlog('33c8b626-ace0-4d19-8c93-6eb3ff10e56e');
    editBlog('0');
}
function readBlog() {
let lstBlog = getBlogs();

for (let i = 0; i < lstBlog.length; i++) {
    const item = lstBlog[i];
    console.log(item.Name);
    console.log(item.Address);
    console.log(item.Description);

}
}
function editBlog(id) {
    // let lstBlog = getBlogs();
    // let lst=lstBlog.filter(x=> x.Id===id);//generate array //= is not true
    // if (lst ===null || lst===undefined)
    // {
    //     console.log('No data found');//answer is undefinded
    //     return;
    // }
    // let item=lst[0];
    // console.log(item);
    let lstBlog = getBlogs();
    let lst=lstBlog.filter(x=> x.Id===id);//generate array //= is not true
    //console.log(lst);
    if (lst.length===0)
    {
        console.log('No data found');//answer is undefinded
        return;
    }
    let item=lst[0];
    console.log(item);
}
function createBlog(name, address, description) {
    // let lstBlogs = [];//Array
    // let blogStr = localStorage.getItem(dotnetT);
    // if (blogStr != null) {
    //     lstBlogs = JSON.parse(blogStr);
    // }
    let lstBlog = getBlogs();
    const blog = {
        Id: uuidv4(),
        Name: name,
        Address: address,
        Description: description
    }
    //lstBlogs.push(blog);
    lstBlog.push(blog);
    //let jsonStr = JSON.stringify(blog);
    //let jsonStr = JSON.stringify(lstBlogs);
    let jsonStr = JSON.stringify(lstBlog);
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
function getBlogs()
{
    let lstBlogs = [];//Array
    let blogStr = localStorage.getItem(dotnetT);
    if (blogStr != null) {
        lstBlogs = JSON.parse(blogStr);
    }
    return lstBlogs;
}