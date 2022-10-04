class Block extends TwitterElement {
    $isBlock;
    /**
     * 
     * @param {*} twitterElementJSON 
     * @param {*} profileJSON 
     * @param {*} isBlock if true it will show the blocked message if false it will show suspended message
     */
    constructor(twitterElementJSON, profileJSON, isBlock) {
        super(
            twitterElementJSON.theme,
            twitterElementJSON.font,
            document.getElementById("blockSuspendTemplate").content.cloneNode(true).firstElementChild
        );
        this.$isBlock = isBlock;
        this.profile = new Profile(
            {
                displayNameElement: this.container.querySelector(".displayName"),
                userNameElement: [...this.container.getElementsByClassName("usernameOutput")],
                profilePicElement: this.container.querySelector(".pfp-image"),
                verifiedElement: this.container.querySelector(".verified"),
            },
            profileJSON.displayName,
            profileJSON.userName,
            profileJSON.profilePic,
            profileJSON.verified,
        );
        this.#updateUIBlock();
    }
    #updateUIBlock() {
        let hide, show;
        let sus = [...this.container.getElementsByClassName("tl-suspend")];
        let block = [...this.container.getElementsByClassName("tl-block")];
        if (this.$isBlock) {
            hide = sus;
            show = block;
        } else {
            hide = block;
            show = sus;
        }
        //console.log(hide,show);
        hide.forEach(e => e.classList.add("hide"));
        show.forEach(e => e.classList.remove("hide"));
    }
    get isBlock() { return this.$isBlock; }
    set isBlock(val) {
        this.$isBlock = val;
        this.#updateUIBlock();
    }

}