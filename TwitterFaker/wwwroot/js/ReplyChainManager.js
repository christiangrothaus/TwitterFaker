class Reply {
  constructor(id, displayName, username, dateTime, profilePicture, body, verified, retweets, quoteTweets, likes, index) {
    this.id = id
    this.displayName = displayName
    this.username = username
    this.dateTime = dateTime
    this.profilePicture = profilePicture
    this.body = body
    this.verified = verified
    this.retweets = retweets
    this.quoteTweets = quoteTweets
    this.likes = likes
    this.index = index
  }

}

class ReplyPaginationController {
  constructor(container, formTemplate, pageButtonTemplate, addButton, deleteButton, pageButtons) {
    this.container = container
    this.formTemplate = formTemplate
    this.pageButtonTemplate = pageButtonTemplate
    this.addButton = addButton
    this.deleteButton = deleteButton
    this.pageButtons = pageButtons
    this.selectedForm = 1
    this.replyCount = 2
  }

  loadReplyChain(replies) {
    let formIndex = 1;
    for (i = 0; i < 2; i++) {
      this.container.querySelector(`#reply${formIndex} #inputDisplayName${formIndex}`).value = replies[i].displayName
      this.container.querySelector(`#reply${formIndex} #inputDisplayName${formIndex}`).value = replies[i].displayName
      this.container.querySelector(`#reply${formIndex} #inputDisplayName${formIndex}`).value = replies[i].displayName


    }
    for (i = 2; i < replies.length; i++) {

    }
  }

  addReply() {
    if (this.replyCount < 8) {
      let dbIndex = this.replyCount
      this.replyCount++
      // Creates new form
      let replyForm = this.formTemplate.content.cloneNode(true).firstElementChild
      this.container.appendChild(replyForm)

      document.getElementById("tinputDisplayName").setAttribute("name", `replies[${dbIndex}].DisplayName`)
      document.getElementById("tinputUserName").setAttribute("name", `replies[${dbIndex}].UserName`)
      document.getElementById("tinputDateTime").setAttribute("name", `replies[${dbIndex}].DateTime`)
      document.getElementById("tinputPfp").setAttribute("name", `profilePicture${dbIndex + 1}`)
      document.getElementById("tinputBody").setAttribute("name", `replies[${dbIndex}].Body`)
      document.getElementById("tinputVerified").setAttribute("name", `replies[${dbIndex}].Verified`)
      document.getElementById("tinputRetweets").setAttribute("name", `replies[${dbIndex}].Retweets`)
      document.getElementById("tinputQuoteTweets").setAttribute("name", `replies[${dbIndex}].QuoteTweets`)
      document.getElementById("tinputLikes").setAttribute("name", `replies[${dbIndex}].Likes`)
      document.getElementById("tinputIndex").setAttribute("name", `replies[${dbIndex}].Index`)
      document.getElementById("tinputIndex").value = dbIndex

      document.getElementById("treply").id = `reply${this.replyCount}`
      document.getElementById("tinputDisplayName").id = `inputDisplayName${this.replyCount}`
      document.getElementById("tinputUserName").id = `inputUserName${this.replyCount}`
      document.getElementById("tinputDateTime").id = `inputDateTime${this.replyCount}`
      document.getElementById("tinputPfp").id = `inputPfp${this.replyCount}`
      document.getElementById("tinputBody").id = `inputBody${this.replyCount}`
      document.getElementById("tinputVerified").id = `inputVerified${this.replyCount}`
      document.getElementById("tinputRetweets").id = `inputRetweets${this.replyCount}`
      document.getElementById("tinputQuoteTweets").id = `inputQuoteTweets${this.replyCount}`
      document.getElementById("tinputLikes").id = `inputLikes${this.replyCount}`
      document.getElementById("tinputIndex").id = `inputIndex${this.replyCount}`
      document.getElementById("tfileClearBtn").id = `fileClearBtn${this.replyCount}`
      // Creates new page button
      let paginationButton = this.pageButtonTemplate.content.cloneNode(true).firstElementChild
      this.pageButtons.appendChild(paginationButton)
      document.querySelector("#pageList .active").classList.remove("active")
      document.getElementById("tpage").innerText = `${this.replyCount}`
      document.getElementById("tpage").classList.add("active")
      document.getElementById("tpage").id = `page${this.replyCount}`
      // Shows correct form
      let shownForm = document.querySelector("#replyForms .shown")
      shownForm.classList.add("visually-hidden")
      shownForm.classList.remove("shown")
      // Updates selected form index to be the reply count
      this.selectedForm = this.replyCount
    }
  }

  deleteReply() {
    if (this.replyCount > 2) {
      let formDeleted = parseInt(this.selectedForm)
      this.replyCount--
      document.querySelector(`#pageList :nth-child(${formDeleted})`).remove();
      document.querySelector(`#reply${formDeleted}`).remove()
      if (this.selectedForm - 1 === this.replyCount) {
        this.selectReply(this.replyCount)
      }
      else {
        let formToEdit = parseInt(formDeleted) + 1
        for (formDeleted; formDeleted <= this.replyCount; formDeleted++) {
          let dbIndex = formDeleted - 1
          this.container.querySelector(`#inputDisplayName${formToEdit}`).setAttribute("name", `replies[${dbIndex}].DisplayName`)
          this.container.querySelector(`#inputUserName${formToEdit}`).setAttribute("name", `replies[${dbIndex}].UserName`)
          this.container.querySelector(`#inputDateTime${formToEdit}`).setAttribute("name", `replies[${dbIndex}].DateTime`)
          this.container.querySelector(`#inputPfp${formToEdit}`).setAttribute("name", `profilePicture${dbIndex}`)
          this.container.querySelector(`#inputBody${formToEdit}`).setAttribute("name", `replies[${dbIndex}].Body`)
          this.container.querySelector(`#inputVerified${formToEdit}`).setAttribute("name", `replies[${dbIndex}].Verified`)
          this.container.querySelector(`#inputRetweets${formToEdit}`).setAttribute("name", `replies[${dbIndex}].Retweets`)
          this.container.querySelector(`#inputQuoteTweets${formToEdit}`).setAttribute("name", `replies[${dbIndex}].QuoteTweets`)
          this.container.querySelector(`#inputLikes${formToEdit}`).setAttribute("name", `replies[${dbIndex}].Likes`)
          this.container.querySelector(`#inputIndex${formToEdit}`).setAttribute("name", `replies[${dbIndex}].Index`)
          this.container.querySelector(`#inputIndex${formToEdit}`).value = dbIndex

          this.container.querySelector(`#reply${formToEdit}`).id = `reply${formDeleted}`
          this.container.querySelector(`#inputDisplayName${formToEdit}`).id = `inputDisplayName${formDeleted}`
          this.container.querySelector(`#inputUserName${formToEdit}`).id = `inputUserName${formDeleted}`
          this.container.querySelector(`#inputDateTime${formToEdit}`).id = `inputDateTime${formDeleted}`
          this.container.querySelector(`#inputPfp${formToEdit}`).id = `inputPfp${formDeleted}`
          this.container.querySelector(`#inputBody${formToEdit}`).id = `inputBody${formDeleted}`
          this.container.querySelector(`#inputVerified${formToEdit}`).id = `inputVerified${formDeleted}`
          this.container.querySelector(`#inputRetweets${formToEdit}`).id = `inputRetweets${formDeleted}`
          this.container.querySelector(`#inputQuoteTweets${formToEdit}`).id = `inputQuoteTweets${formDeleted}`
          this.container.querySelector(`#inputLikes${formToEdit}`).id = `inputLikes${formDeleted}`
          this.container.querySelector(`#inputIndex${formToEdit}`).id = `inputIndex${formDeleted}`
          this.container.querySelector(`#fileClearBtn${formToEdit}`).id = `fileClearBtn${formDeleted}`
          this.pageButtons.querySelector(`#page${formToEdit}`).innerText = `${formDeleted}`
          this.pageButtons.querySelector(`#page${formToEdit}`).id = `page${formDeleted}`
          formToEdit++
        }
        this.selectReply(this.selectedForm)
      }
    }
  }

  selectReply(index) {
    if (document.querySelector("#replyForms .shown") !== null) {
      document.querySelector(`#pageList .active`).classList.remove("active")
      let shownForm = document.querySelector("#replyForms .shown")
      shownForm.classList.add("visually-hidden")
      shownForm.classList.remove("shown")
    }
    document.querySelector(`#page${index}`).classList.add("active")
    let formToShow = document.querySelector(`#replyForms #reply${index}`)
    formToShow.classList.remove("visually-hidden")
    formToShow.classList.add("shown")
    this.selectedForm = index
  }
}