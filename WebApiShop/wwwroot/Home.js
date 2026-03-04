const postResponse = async () => { 

    const userN = document.querySelector("#userName");
    const fName = document.querySelector("#firstName");
    const lName = document.querySelector("#lastName");
    const pass = document.querySelector("#password");

    const postData = {
<<<<<<< HEAD
    UserName: userN.value,
=======
    UserEmail: userN.value,
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
    FirstName: fName.value,
    LastName: lName.value,
    Password: pass.value,
    Id:0
};

    const responsePost = await fetch("https://localhost:44320/api/Users", {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(postData)
});

    const dataPost = await responsePost.json();
<<<<<<< HEAD
    sessionStorage.setItem("user", JSON.stringify(dataPost))
    if (responsePost.status == 201)
        alert("משתמש נוסף בהצלחה");
    else if (responsePost.status == 400)
        alert("סיסמא חלשה נסה שנית");
    else
        alert("תהליך ההרשמה נכשל...  נסה שוב");
    
=======
    sessionStorage.setItem("user", JSON.stringify(dataPost));
    if (responsePost.status==201)
        alert("משתמש נוסף בהצלחה");
    else if (responsePost.status == 400)
        alert("סיסמא חלשה, נסה שנית")
    else
        alert("הליך ההרשמה נכשל, אנא נסה שנית 🤗 . ")
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
}

const login = async () => {
    const userN = document.querySelector("#userN").value;
<<<<<<< HEAD
    const pass = document.querySelector("#pass");
    const postDataLogin = {

        UserName: userN,
        FirstName: "",
        LastName: "",
        Password: pass.value,
=======
    const pass = document.querySelector("#pass").value;
    const postDataLogin = {

        UserEmail: userN,
        FirstName: "",
        LastName: "",
        Password: pass,
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        Id: 0
    };

    const responsePostLogin = await fetch("https://localhost:44320/api/Users/Login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postDataLogin)

    });

<<<<<<< HEAD
   
=======
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
    if (responsePostLogin.ok) {
        const dataPostLogin = await responsePostLogin.json();
        sessionStorage.setItem("user", JSON.stringify(dataPostLogin))
        alert("wellcome!!!!!!!")
        window.location.href = "../Update.html"
    }
    else {
<<<<<<< HEAD

          alert("אופסססססססססס המשתמש לא קיים")
    }
      
=======
        alert("אופסססססססססס שם או סיסמא לא קיימים במערכת")
    }
   
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca



}