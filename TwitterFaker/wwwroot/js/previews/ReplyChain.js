class ReplyTweet {
    constructor(profileJSON, textImageDateTimeStatsJSON) {
        this.replyElement = document.getElementById("replyChainTweetTemplate").content.cloneNode(true).firstElementChild;

        this.profile = new Profile(
            {
                displayNameElement: this.replyElement.querySelector(".name"),
                userNameElement: this.replyElement.querySelector(".username"),
                profilePicElement: this.replyElement.querySelector(".pfp"),
                verifiedElement: this.replyElement.querySelector(".verified"),
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
                textElement: this.replyElement.querySelector(".tweetText"),
                imageElement: this.replyElement.querySelector(".imgContainer .img"),
                imageContainerElement: this.replyElement.querySelector(".imgContainer"),
                dateElement: this.replyElement.querySelector(".nameContainer .date"),
                timeElement: null,
                statsElements: [
                    this.replyElement.querySelector(".replies"),
                    this.replyElement.querySelector(".retweets"),
                    this.replyElement.querySelector(".likes")
                ]
            },
            false
        );
        this.buffer = document.getElementById("replyChainBufferTemplate").content.cloneNode(true).firstElementChild;
    }
}
class ReplyChain extends TwitterElement {
    ///array of reply tweets
    #replies = [];
    constructor(twitterElementJSON, tweets = []) {
        super(
            twitterElementJSON.theme,
            twitterElementJSON.font,
            document.getElementById("replyChainBaseTemplate").content.cloneNode(true).firstElementChild
        );
        this.tweetInnerContainer = this.container.querySelector(".tweetInnerContainer");
        for (const t of tweets) {
            this.addReply(t);
        }
    }
    addReply(t) {
        let reply = new ReplyTweet(t.profileJSON, t.textImageDateTimeStatsJSON);
        if (this.#replies.length > 0)
            this.tweetInnerContainer.appendChild(reply.buffer);
        this.tweetInnerContainer.appendChild(reply.replyElement);
        this.#replies.push(reply);
        return reply;
    }
    removeReply(index) {
        if (this.#replies.length - 1 < index)
            throw "Out of Bounds reply index: " + index;
        let rep = this.#replies.pop(index);
        //console.log(rep);
        rep.replyElement.parentElement.removeChild(rep.replyElement);
        if (rep.buffer.parentElement == this.tweetInnerContainer)
            rep.buffer.parentElement.removeChild(buffer);
    }
    get Replies() { return this.#replies }

}