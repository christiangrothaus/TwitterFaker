class Tweet extends TwitterElement {
    #clientElement; #debunkElement;
    #client; #debunk;
    constructor(twitterElementJSON, profileJSON, textImageDateTimeStatsJSON, client, debunk) {
        super(
            twitterElementJSON.theme,
            twitterElementJSON.font,
            document.getElementById("tweetTemplate").content.cloneNode(true).firstElementChild
        );
        //let clone=;
        //this.container=clone.firstElementChild;
        this.profile = new Profile(
            {
                displayNameElement: this.container.querySelector(".displayName"),
                userNameElement: this.container.querySelector(".userNameText"),
                profilePicElement: this.container.querySelector(".profileImg"),
                verifiedElement: this.container.querySelector(".verified"),
            },
            profileJSON.displayName,
            profileJSON.userName,
            profileJSON.profilePic,
            profileJSON.verified,
        );
        this.TextImageDateTimeStats = new TextImageDateTimeStats(
            textImageDateTimeStatsJSON.text,
            textImageDateTimeStatsJSON.image,
            textImageDateTimeStatsJSON.dateTime,
            textImageDateTimeStatsJSON.stats,
            {
                textElement: this.container.querySelector(".tweetText"),
                imageElement: this.container.querySelector(".tweetImg"),
                imageContainerElement: this.container.querySelector(".imgContainer"),
                dateElement: this.container.querySelector(".detailDate"),
                timeElement: this.container.querySelector(".detailTime"),
                statsElements: [
                    this.container.querySelector(".retweets"),
                    this.container.querySelector(".quotes"),
                    this.container.querySelector(".likes")
                ]
            }
        );
        this.#clientElement = this.container.querySelector(".detailClient");
        this.#client = client;
        this.#debunkElement = this.container.querySelector(".debunk");
        this.#debunk = debunk;
        this.#updateUITweet();
    }
    #updateUITweet() {
        if (this.#client != null && this.#client.length > 0) {
            this.#clientElement.classList.remove("hide");
            this.#clientElement.querySelector(".detailClientText").innerHTML = this.#client;
        } else {
            this.#clientElement.classList.add("hide");
        }

        if (this.#debunk != null && this.#debunk.length > 0) {
            this.#debunkElement.classList.remove("hide");
            this.#debunkElement.querySelector(".debunkText").innerHTML = this.#debunk;
        } else {
            this.#debunkElement.classList.add("hide");
        }
    }
    get debunk() { return this.#debunk }
    set debunk(newVal) {
        this.#debunk = newVal;
        this.#updateUITweet();
    }
    get client() { return this.#client }
    set client(newVal) {
        this.#client = newVal;
        this.#updateUITweet();
    }
}