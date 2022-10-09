class TextImageDateTimeStats {
    #text; #image; #dateTime; #stats; #elements; #hideButton
    constructor(text, image, dateTime, stats, elements, hideButton = true) {
        this.#text = text;
        this.#image = image;
        this.#dateTime = dateTime;
        this.#stats = stats;
        this.#hideButton = hideButton;
        this.#elements = elements;
        this.#updateUIStat();
    }
    #updateUIStat() {
        let e = this.#elements;
        //Text

        e.textElement.innerHTML = this.#text.replace(/[@#][\w_]+/g, `<span class="simulatedLink">$&</span>`);

        //Image
        if (this.#image != null) {
            e.imageContainerElement.classList.remove("hide");
            e.imageElement.src = this.#image;
        } else {
            e.imageContainerElement.classList.add("hide");
        }

        //Date
        let dt = this.#dateTime;
        let currentDate = new Date();
        let date = `${Months[dt.getMonth()]} ${dt.getDate()}`;
        if (currentDate.getFullYear() != dt.getFullYear()) {
            date += `, ${dt.getUTCFullYear()}`;
        }
        e.dateElement.innerHTML = date;
        console.log(this.timeElement);
        //time
        if (e.timeElement != null) {
            e.timeElement.innerHTML = dt.toLocaleTimeString().replace(/:\d+ /g, " ");
        }

        //Stats
        for (const i in e.statsElements) {
            let statElement = e.statsElements[i];
            let stat = this.#stats[i];
            if (this.#hideButton) {
                if (stat > 0) {
                    statElement.classList.remove("hide");
                    statElement.querySelector(".tweetNumberBold").innerHTML = TextImageDateTimeStats.addPrefix(stat);
                    statElement.querySelector(".numberPlural").innerHTML = stat > 1 ? "s" : "";
                } else {
                    statElement.classList.add("hide");
                }
            } else {
                if (stat > 0)
                    statElement.innerHTML = TextImageDateTimeStats.addPrefix(stat);
                else
                    statElement.innerHTML = "";
            }
        }
        if (this.#hideButton) {
            e.statsElements[0].parentElement.parentElement.style.display = (this.#stats.find(e => e > 0) == undefined) ? "none" : "";
        }
       
    }
    static addPrefix(n) {
        let places = [[1e0, ""], [1e3, 'K'], [1e6, 'M'], [1e9, 'B'], [1e12, 'T']]
        let lastPlace = places[0];
        for (const place of places) {
            if (place[0] > n)
                return (Math.round(n / (lastPlace[0] / 10)) / 10) + lastPlace[1];
            else
                lastPlace = place;
        }
    }
    get text() { return this.#text; }
    set text(newVal) {
        this.#text = newVal;
        this.#updateUIStat();
    }

    get image() { return this.#image; }
    set image(newVal) {
        if (newVal == "")
            newVal = null;
        this.#image = newVal;
        this.#updateUIStat();
    }

    get dateTime() { return this.#dateTime; }
    set dateTime(newVal) {
        this.#dateTime = newVal;
        this.#updateUIStat();
    }

    get stats() { return this.#stats; }
    set stats(newVal) {
        this.#stats = newVal;
        this.#updateUIStat();
    }
}