const txtin = document.querySelector("#in");
const input = document.querySelector("#txt-inp");

input.addEventListener("change", () =>
{
    showText(input.files[0]);
})

const showText = (file) =>
{
    const reader = new FileReader();
    reader.readAsText(file, "windows-1251");
    var strarr = [];
    reader.onload = e =>
    {
        strarr = reader.result.split(",");
        var str = `<ul class="list-unstyled">`;
        for (var i = 0; i < strarr.length; i++)
        {
            str += `<li>${strarr[i]}</li>`;
        }
        str += "</ul>";
        txtin.innerHTML = str;
    }
}