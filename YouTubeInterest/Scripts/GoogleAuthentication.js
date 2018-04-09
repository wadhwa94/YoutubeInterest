/// <reference path="jquery-1.10.2.min.js" />
function getAccessToken() {
    console.log(location.href);
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                isUserRegistered(accessToken);
            }
        }
    }
}

function isUserRegistered(accessToken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        method: 'GET',
        headers: {
            'content-type': 'application/JSON',
            'Authorization' : 'Bearer ' + accessToken
        },
        success: function (response) {
            if (response.HasRegistered) {
                localStorage.setItem('accessToken', accessToken);
                localStorage.setItem('userName', response.Email);
                console.warn("Access Token" + accessToken);
                console.warn("user Name" + response.Email);

                console.warn("Response" + JSON.stringify(response));

                //sessionStorage.setItem('accessToken', accessToken);
                //sessionStorage.setItem('userName', response.Email);
                window.location.href = "Data.html";
            }
            else {
                signupExternalUser(accessToken);
            }
        },
        error: function (data) {
            console.warn("Entered the error " + data.responseText + " " + accessToken);
        }

    });
}

function signupExternalUser(accessToken) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        method: 'POST',
        //access_type: "offline",
        //approval_prompt: "force",
        headers: {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            //window.location.href = "/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A63890%2FLogin.html&state=W8XaDpYusZXDM6MZK4kN9gjHRgR4Uu5iknoOPz22Q2w1";
            window.location.href = "/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=https%3A%2F%2Fyoutubeinterest.azurewebsites.net%2FLogin.html&state=gQ7rVK6ghAaKo0EWKycoealsoVKJw641GyLktyeISuA1";
        }
    });
    
}