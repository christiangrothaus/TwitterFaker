const defaultPfp = "data:image/png;base64,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";
class SelectVavlue {
    constructor(id, displayName, className) {
        this.id = id;
        this.displayName = displayName;
        this.className = className;
    }
}
const Months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
const Fonts = [
    new SelectVavlue(0, "Default", ""),
    new SelectVavlue(1, "Inter", "interFont"),
    new SelectVavlue(2, "Chirp", "chirp"),
];
const Themes = [
    new SelectVavlue(0, "Default", ""),
    new SelectVavlue(1, "Dim", "Dim"),
    new SelectVavlue(2, "Dark", "Dark"),
];

class TwitterElement {
    #theme; #font;
    constructor(theme, font, container) {
        this.#theme = theme;
        this.#font = font;
        this.container = container;
        this.#setSelectValue(this.#font, Fonts);
        this.#setSelectValue(this.#theme, Themes);
    }
    #setSelectValue(id, svList) {
        this.container.classList.remove(...svList.map(e => e.className).filter(z => z != ""));
        if (svList[id].className != "")
            this.container.classList.add(svList[id].className);
    }
    get theme() {
        return this.#theme;
    }
    set theme(t) {
        this.#theme = t;
        this.#setSelectValue(this.#theme, Themes);
    }
    get font() {
        return this.#font;
    }
    set font(t) {
        this.#font = t;
        this.#setSelectValue(this.#font, Fonts);
    }
}
class Profile {
    #displayName; #userName; #profilePic; #verified;
    constructor(profileElements, displayName = "Name", userName = "username", profilePic = null, verified = false) {
        this.#displayName = displayName;
        this.#userName = userName;
        this.#profilePic = profilePic;
        this.#verified = verified;
        this.profileElements = profileElements;
        this.updateUI();
    }
    updateUI() {
        let pe = this.profileElements;
        pe.displayNameElement.innerHTML = this.#displayName;

        if (Array.isArray(pe.userNameElement)) {
            pe.userNameElement.forEach(e => e.innerHTML = this.#userName);
        } else {
            pe.userNameElement.innerHTML = this.#userName;
        }

        pe.profilePicElement.src = (this.#profilePic == null)? defaultPfp : this.#profilePic;

        if (this.#verified)
            pe.verifiedElement.classList.remove("hide");
        else
            pe.verifiedElement.classList.add("hide");

    }
    get displayName() {
        return this.#displayName;
    }
    set displayName(dn) {
        this.#displayName = dn;
        this.updateUI();
    }

    get userName() {
        return this.#userName;
    }
    set userName(newuserName) {
        this.#userName = newuserName;
        this.updateUI();
    }

    get profilePic() {
        return this.#profilePic;
    }
    set profilePic(newprofilePic) {
        if (newprofilePic == "") {
            newprofilePic = null;
        }
        this.#profilePic = newprofilePic;
        this.updateUI();
    }

    get verified() {
        return this.#verified;
    }
    set verified(newverified) {
        this.#verified = newverified;
        this.updateUI();
    }

}