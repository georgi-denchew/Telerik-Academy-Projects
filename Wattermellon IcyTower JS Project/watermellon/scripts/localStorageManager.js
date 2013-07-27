var localStorageManager =
{

    setPlayerType: function (playerType)
    {
        localStorage.setItem("playerType", playerType);
    },

    getPlayerType: function ()
    {
        return localStorage.getItem("playerType");
    },

    setFloorColor: function (floorColor) {
        localStorage.setItem("floorColor", floorColor);
    },

    getFloorColor: function () {
        return localStorage.getItem("floorColor");
    }
};