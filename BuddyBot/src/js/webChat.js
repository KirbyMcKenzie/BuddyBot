function setupWebChat() {

    const styleOptions = {
        //General
        suggestedActionBackground: '#2E5EFF',
        suggestedActionBorder: 'none',
        suggestedActionBorderRadius: 10,
        suggestedActionTextColor: 'white',

        // BuddyBot
        bubbleBackground: '#E3E8F1',
        bubbleTextColor: '#32353A',
        bubbleBorderRadius: 10,
        bubbleBorder: 'none',

        // User
        bubbleFromUserBackground: '#2E5EFF',
        bubbleFromUserTextColor: 'white',
        bubbleFromUserBorderRadius: 10,
        bubbleFromUserBorder: 'none'
    };

    window.WebChat.renderWebChat({
        directLine: window.WebChat.createDirectLine({ secret: 'GWLuPsYNedU.cwA.khE.I3LeUlKURhomRrIo2FoLPM7amVzG594CvWOczgxpC30' }),
        userID: getUserId(),
        styleOptions
    },
        document.getElementById('webchat'));
}

function getUserId() {

    function generateUniqueID() {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    }

    var userId = localStorage.getItem('userId');

    if (userId === null || userId === undefined) {
        userId = (generateUniqueID() + generateUniqueID() + "-" + generateUniqueID() + "-4"
            + generateUniqueID().substr(0, 3) + "-" + generateUniqueID() + "-" + generateUniqueID()
            + generateUniqueID() + generateUniqueID()).toLowerCase();

        localStorage.setItem('userId', userId);
    }

    return userId;
}

setupWebChat();