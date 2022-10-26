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

  loadPreviews() {
    let replyForms = document.querySelectorAll("#replyForms [id^=reply]")
    let replyChainPreview = document.querySelector("#replyChainPreview")
    let themes = new Map()
    themes.set(0, "Default")
    themes.set(1, "Dim")
    themes.set(2, "Dark")
    let fonts = new Map()
    fonts.set(0, "Default")
    fonts.set(1, "interFont")
    fonts.set(2, "chirp")
    let selectedTheme = document.querySelector("#themeRadio input:checked").value
    let selectedFont = document.querySelector("#fontRadio input:checked").value

    document.getElementById("replyChainPreview").innerHTML = ""
    document.getElementById("replyChainPreview").setAttribute("class", "replyChain")
    replyForms.forEach(reply => {
      let displayName = reply.querySelector("[id^=inputDisplayName]").value
      let username = reply.querySelector("[id^=inputUserName]").value
      let dateTime = reply.querySelector("[id^=inputDateTime]").value
      let profilePicture = reply.querySelector("[id^=pfpPlaceHolder]").value
      let profilePictureInput = reply.querySelector("[id^=inputPfp]")
      let body = reply.querySelector("[id^=inputBody]").value
      let verified = reply.querySelector("[id^=inputVerified]").checked
      let retweets = reply.querySelector("[id^=inputRetweets]").value
      let quoteTweets = reply.querySelector("[id^=inputQuoteTweets]").value
      let likes = reply.querySelector("[id^=inputLikes]").value

      dateTime = new Date(dateTime)
      dateTime = dateTime.toLocaleString('en-US', {
        month: "short",
        day: "2-digit"
      })

      retweets = KiloFormat(retweets)
      quoteTweets = KiloFormat(quoteTweets)
      likes = KiloFormat(likes)

      let replyPreview = document.querySelector(`#replyTemplate`).content.cloneNode(true).firstElementChild
      if (profilePictureInput.files.length > 0) {
        var reader = new FileReader();
        reader.readAsDataURL(profilePictureInput.files[0])
        reader.onload = () => {
          console.log(reader.result)
          replyPreview.querySelector(".pfp").setAttribute("src", `${reader.result}`)
        }
      } else if (profilePicture !== "") {
        replyPreview.querySelector(".pfp").setAttribute("src", `data:image/png;base64,${profilePicture}`)
      } else {
        replyPreview.querySelector(".pfp").setAttribute("src", "data:image/png;base64,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")
      }
      replyPreview.querySelector(".name").innerText = displayName
      if (!verified) {
        replyPreview.querySelector(".verified").innerHTML = ""
      }
      replyPreview.querySelector(".username").innerText = username
      replyPreview.querySelector(".tweetText").innerText = body
      replyPreview.querySelector(".date").innerText = dateTime
      replyPreview.querySelector(".replies").innerText = quoteTweets
      replyPreview.querySelector(".retweets").innerText = retweets
      replyPreview.querySelector(".likes").innerText = likes
      replyChainPreview.classList.add(themes.get(parseInt(selectedTheme)))
      replyChainPreview.classList.add(fonts.get(parseInt(selectedFont)))
      document.querySelector(`#replyChainPreview`).appendChild(replyPreview)
    });
  }

  loadReplies(replies) {
    if (replies !== null && replies !== undefined) {
      for (let i = 2; i < replies.length; i++) {
        let formIndex = i + 1;
        this.addReply(false)
        document.querySelector(`#inputDisplayName${formIndex}`).value = replies[i].displayName
        document.querySelector(`#inputUserName${formIndex}`).value = replies[i].userName
        document.querySelector(`#inputDateTime${formIndex}`).value = replies[i].dateTime
        document.querySelector(`#inputBody${formIndex}`).value = replies[i].body
        document.querySelector(`#inputVerified${formIndex}`).value = replies[i].verified
        document.querySelector(`#inputRetweets${formIndex}`).value = replies[i].retweets
        document.querySelector(`#inputQuoteTweets${formIndex}`).value = replies[i].quoteTweets
        document.querySelector(`#inputLikes${formIndex}`).value = replies[i].likes
        document.querySelector(`#inputIndex${formIndex}`).value = replies[i].index
        document.querySelector(`#inputReplyId${formIndex}`).value = replies[i].replyId
        if (replies[i].profilePicture !== null) {
          document.querySelector(`#pfpPlaceHolder${formIndex}`).value = replies[i].profilePicture
        }
        if (replies[i].verified) {
          document.querySelector(`#inputVerified${formIndex}`).setAttribute("checked", "")
        }
      }
    }
  }

  addReply(changeForm = true) {
    if (this.replyCount < 8) {
      let dbIndex = this.replyCount
      this.replyCount++
      // Creates new form
      let replyForm = this.formTemplate.content.cloneNode(true).firstElementChild
      this.container.appendChild(replyForm)

      document.getElementById("tinputDisplayName").setAttribute("name", `Replies[${dbIndex}].DisplayName`)
      document.getElementById("tinputUserName").setAttribute("name", `Replies[${dbIndex}].UserName`)
      document.getElementById("tinputDateTime").setAttribute("name", `Replies[${dbIndex}].DateTime`)
      document.getElementById("tinputPfp").setAttribute("name", `profilePicture${dbIndex + 1}`)
      document.getElementById("tinputBody").setAttribute("name", `Replies[${dbIndex}].Body`)
      document.getElementById("tinputVerified").setAttribute("name", `Replies[${dbIndex}].Verified`)
      document.getElementById("tinputRetweets").setAttribute("name", `Replies[${dbIndex}].Retweets`)
      document.getElementById("tinputQuoteTweets").setAttribute("name", `Replies[${dbIndex}].QuoteTweets`)
      document.getElementById("tinputLikes").setAttribute("name", `Replies[${dbIndex}].Likes`)
      document.getElementById("tinputIndex").setAttribute("name", `Replies[${dbIndex}].Index`)
      document.getElementById("tpfpPlaceHolder").setAttribute("name", `Replies[${dbIndex}].ProfilePicture`)
      document.getElementById("tinputReplyId").setAttribute("name", `Replies[${dbIndex}].ReplyId`)
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
      document.getElementById("tpfpPlaceHolder").id = `pfpPlaceHolder${this.replyCount}`
      document.getElementById("tinputReplyId").id = `inputReplyId${this.replyCount}`
      // Creates new page button
      let paginationButton = this.pageButtonTemplate.content.cloneNode(true).firstElementChild
      this.pageButtons.appendChild(paginationButton)
      document.getElementById("tpage").innerText = `${this.replyCount}`
      document.getElementById("tpage").id = `page${this.replyCount}`
      if (changeForm) {
        // Select correct page button
        document.querySelector("#pageList .active").classList.remove("active")
        document.getElementById(`page${this.replyCount}`).classList.add("active")
        // Shows correct form
        let shownForm = document.querySelector("#replyForms .shown")
        shownForm.classList.add("visually-hidden")
        shownForm.classList.remove("shown")
        let formToShow = document.querySelector(`#replyForms #reply${this.replyCount}`)
        formToShow.classList.add("shown")
        formToShow.classList.remove("visually-hidden")
      }
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
          this.container.querySelector(`#inputDisplayName${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].DisplayName`)
          this.container.querySelector(`#inputUserName${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].UserName`)
          this.container.querySelector(`#inputDateTime${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].DateTime`)
          this.container.querySelector(`#inputPfp${formToEdit}`).setAttribute("name", `profilePicture${dbIndex}`)
          this.container.querySelector(`#inputBody${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].Body`)
          this.container.querySelector(`#inputVerified${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].Verified`)
          this.container.querySelector(`#inputRetweets${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].Retweets`)
          this.container.querySelector(`#inputQuoteTweets${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].QuoteTweets`)
          this.container.querySelector(`#inputLikes${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].Likes`)
          this.container.querySelector(`#inputIndex${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].Index`)
          this.container.querySelector(`#inputReplyId${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].ReplyId`)
          this.container.querySelector(`#pfpPlaceHolder${formToEdit}`).setAttribute("name", `Replies[${dbIndex}].ProfilePicture`)
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
          this.container.querySelector(`#inputReplyId${formToEdit}`).id = `inputIndex${formDeleted}`
          this.container.querySelector(`#pfpPlaceHolder${formToEdit}`).id = `pfpPlaceHolder${formDeleted}`
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

function KiloFormat(num) {
  if (num >= 100000000) {
    return (num / 1000000).toFixed(0) + "M";
  }

  if (num >= 1000000) {
    num = (num / 1000000).toFixed(1)
    if (num.charAt(num.length - 1) == 0) {
      num = num.slice(0, num.length - 2)
    }
    return num + "M";
  }

  if (num >= 100000) {
    return (num / 1000).toFixed(0) + "K";
  }

  if (num >= 10000) {
    num = (num / 1000).toFixed(1)
    if (num.charAt(num.length - 1) == 0) {
      num = num.slice(0, num.length - 2)
    }
    return num + "K";
  }

  return num;
}