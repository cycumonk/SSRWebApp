// 設置 Cookie
function setCookie(name, value) {
    document.cookie = name + "=" + (value || "") + "; path=/";
}

// 獲取 Cookie
function getCookie(name) {
    const nameEQ = name + "=";
    const ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

// 當輸入框變更時存儲值到 Cookie
function saveInputValue(inputId) {
    const input = document.getElementById(inputId);
    setCookie(inputId, input.value);
}

// 當頁面加載時從 Cookie 讀取值並設置到輸入框
function loadInputValue(inputId) {
    const inputValue = getCookie(inputId);
    if (inputValue) {
        document.getElementById(inputId).value = inputValue;
    }
}

window.onload = function () {
    const inputs = ["account", "email", "password"];
    inputs.forEach(inputId => {
        loadInputValue(inputId);
        document.getElementById(inputId).addEventListener("input", () => saveInputValue(inputId));
    });
}