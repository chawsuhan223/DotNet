const dotnetT = 'DotNetT';
let _blogId = '';
//must use 'let' DOn't use 'var'
runBlog();
function runBlog() {
    readBlog();
    //createBlog('Test3', 'Test4', 'Test5');
    //editBlog('33c8b626-ace0-4d19-8c93-6eb3ff10e56e');
    //editBlog('0');

    // const id=prompt("Enter ID");
    // deleteBlog(id);

    //const id=prompt("Enter ID");
    //const name=prompt("Enter Name");
    //const address=prompt("Enter Address");
    //const description=prompt("Enter Description");
    //updateBlog(id,name,address,description);
}
function readBlog() {
    let lstBlog = getBlogs();
    $('#tbDataTable').html('');
    let htmlRow = '';
    for (let i = 0; i < lstBlog.length; i++) {
        const item = lstBlog[i];
        htmlRow += `
        <tr>
        <td>
        <button type="button" class="btn btn-success" onclick="editBlog('${item.Id}')">Edit</button>
        <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.Id}')">Delete</button>
        </td>
            <th scope="row">${i + 1}</th>
            <td>${item.Name}</td>
            <td>${item.Address}</td>
            <td>${item.Description}</td>
        </tr>`;
        console.log(htmlRow);
        $('#tbDataTable').html(htmlRow);
    }
}
function editBlog(id) {

    let lstBlog = getBlogs();
    let lst = lstBlog.filter(x => x.Id === id);//generate array //= is not true
    if (lst.length === 0) {
        console.log('No data found');//answer is undefinded
        return;
    }
    let item = lst[0];
    console.log(item);

    $('#Name').val(item.Name);
    $('#Address').val(item.Address);
    $('#Description').val(item.Description);
    _blogId = item.Id;
}
function createBlog(name, address, description) {

    let lstBlog = getBlogs();
    const blog = {
        Id: uuidv4(),
        Name: name,
        Address: address,
        Description: description
    }
    lstBlog.push(blog);

    setLocalStorage(lstBlog);


}
function updateBlog(id, name, address, description) {

    let lstBlog = getBlogs();
    let lst = lstBlog.filter(x => x.Id === id);
    if (lst.length === 0) {
        console.log('No data found');//answer is undefinded
        return;
    }
    let index = lstBlog.findIndex(x => x.Id === id);
    lstBlog[index] = {
        Id: id,
        Name: name,
        Address: address,
        Description: description,
    }
    setLocalStorage(lstBlog);
}
function deleteBlog(id) {

    Notiflix.Confirm.show(
        'Confirm',
        'Are you sure delete it?',
        'Yes',
        'No',
        function okCb() {

            Notiflix.Block.standard('#frm1')
            setTimeout(() => {

                let lstBlog = getBlogs();
                let lst = lstBlog.filter(x => x.Id === id);
                if (lst.length === 0) {
                    console.log('No data found');//answer is undefinded
                    return;
                }
                lstBlog = lstBlog.filter(x => x.Id !== id);
                setLocalStorage(lstBlog);
                successMessage('Deleting Successful');
                readBlog();

            }, 3000);
            Notiflix.Block.remove('#frm1');

            // let lstBlog = getBlogs();
            // let lst = lstBlog.filter(x => x.Id === id);
            // if (lst.length === 0) {
            //     console.log('No data found');//answer is undefinded
            //     return;
            // }
            // lstBlog = lstBlog.filter(x => x.Id !== id);
            // setLocalStorage(lstBlog);
            // successMessage('Deleting Successful');
            // readBlog();
        },
        function cancelCb() {

        })



}




function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}
function getBlogs() {
    let lstBlogs = [];//Array
    let blogStr = localStorage.getItem(dotnetT);
    if (blogStr != null) {
        lstBlogs = JSON.parse(blogStr);
    }
    return lstBlogs;
}
function setLocalStorage(blogs) {
    let jsonStr = JSON.stringify(blogs);
    localStorage.setItem(dotnetT, jsonStr);
}
$('#btnSave').click(function () {
    const name = $('#Name').val();
    const address = $('#Address').val();
    const description = $('#Description').val();
    if (_blogId === '') {
        //Notiflix.Loading.circle();
        //setTimeout(() => {
        createBlog(name, address, description);
        //alert('Saving Successful');
        //Notiflix.Loading.remove();
        successMessage('Saving Successful');
        // }, 3000)
    }
    else {
        // updateBlog(_blogId, name, address, description);
        // //alert('Updating Successful');
        // successMessage('Updating Successful');
        // _blogId = '';

        //Notiflix.Loading.circle();
        //setTimeout(() => {
        updateBlog(_blogId, name, address, description);
        //alert('Saving Successful');
        // Notiflix.Loading.remove();
        successMessage('Updating Successful');
        _blogId = '';
        //}, 3000)
    }

    $('#Name').val('');
    $('#Address').val('');
    $('#Description').val('');
    $('#Name').focus();

    readBlog();

})
function successMessage(message) {
    //Notiflix.Notify.success(message);
    Notiflix.Report.success(
        'Success',
        message,
        'Okay',
    );
}


//https://notiflix.github.io/  Notiflix
//https://sweetalert2.github.io/#examples  SweetAlert