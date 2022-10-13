let replyOne
let replyTwo
let replyCount
let paginationList
let pageAddListItem
let pageAddButton
let replyFormTemplate
let paginationButtonTemplate
let pageDeleteButton
let selectedFormIndex

window.onload = () => {
  replyFormTemplate = document.getElementById("replyFormTemplate")
  paginationButtonTemplate = document.getElementById("pageButttonTemplate")
  pageAddListItem = document.getElementById("pageAddListItem")
  replyOne = document.getElementById("reply")
  replyTwo = document.getElementById("reply2")
  replyFormContainer = document.getElementById("replyForms")
  selectedFormIndex = 1
  replyCount = 2
  paginationList = document.getElementById("pageList")
  pageAddButton = document.getElementById("addReply")
  pageDeleteButton = document.getElementById("deleteSelectedReply")
  //Watches the add reply button and creates a new reply when clicked and switches to the new reply
  pageAddButton.addEventListener("click", addReply)
  //Watches the delete reply button and removes the reply form and pagination button. Also shifts replies index if required.
  pageDeleteButton.addEventListener("click", deleteReply)
  //Watches the pagination list for click and then switches to the one clicked
  paginationList.addEventListener("click", function (e) {
    var target = e.target
    switchReply(target.textContent)
  })
  document.getElementById("defaultTheme").setAttribute("checked", "")
  document.getElementById("defaultFont").setAttribute("checked", "")
}

function addReply() {
  if (replyCount < 8) {
    replyCount++
    createReplyForm(replyCount)
    createPaginationButton(replyCount)
    let shownForm = document.querySelector("#replyForms .shown")
    shownForm.classList.add("visually-hidden")
    shownForm.classList.remove("shown")
    selectedFormIndex = replyCount
  }
}

function createReplyForm(index) {
  replyForm = document.getElementById("replyFormTemplate").content.cloneNode(true).firstElementChild
  replyFormContainer.appendChild(replyForm)
  document.getElementById("treply").id = `reply${index}`
  document.getElementById("tinputDisplayName").id = `inputDisplayName${index}`
  document.getElementById("tinputUserName").id = `inputUserName${index}`
  document.getElementById("tinputDateTime").id = `inputDateTime${index}`
  document.getElementById("tinputPfp").id = `inputPfp${index}`
  document.getElementById("tinputBody").id = `inputBody${index}`
  document.getElementById("tinputVerified").id = `inputVerified${index}`
  document.getElementById("tinputRetweets").id = `inputRetweets${index}`
  document.getElementById("tinputQuoteTweets").id = `inputQuoteTweets${index}`
  document.getElementById("tinputLikes").id = `inputLikes${index}`
}

function createPaginationButton(index) {
  paginationButton = document.getElementById("pageButtonTemplate").content.cloneNode(true).firstElementChild
  paginationList.insertBefore(paginationButton, pageAddListItem)
  document.querySelector("#pageList .active").classList.remove("active")
  document.getElementById("tpage").innerText = `${index}`
  document.getElementById("tpage").classList.add("active")
  document.getElementById("tpage").id = `page${index}`
}

function switchReply(index) {
  document.querySelector(`#pageList .active`).classList.remove("active")
  document.querySelector(`#page${index}`).classList.add("active")
  showForm(index)
  selectedFormIndex = index
}

function showForm(index) {
  let shownForm = document.querySelector("#replyForms .shown")
  shownForm.classList.add("visually-hidden")
  shownForm.classList.remove("shown")
  let formToShow = document.querySelector(`#replyForms #reply${index}`)
  formToShow.classList.remove("visually-hidden")
  formToShow.classList.add("shown")
}

function deleteReply() {
  let intialSelectedFormIndex = selectedFormIndex
  let intialReplyCount = replyCount
  //Selected Form
  if (replyCount > 2) {
    if (selectedFormIndex === replyCount && replyCount !== 2) {
      document.querySelector(`#reply${replyCount--}`).remove()
      document.querySelector(`#reply${replyCount}`).classList.remove("visually-hidden")
      document.querySelector(`#reply${replyCount}`).classList.add("shown")
      document.querySelector(`#pageList`).lastElementChild.remove();
      document.querySelector(`#pageList`).lastElementChild.classList.add("active")
      selectedFormIndex = replyCount
    }
    else {
      document.querySelector(`#pageList :nth-child(${selectedFormIndex})`).remove();
      document.querySelector(`#reply${selectedFormIndex++}`).remove()
      replyCount--
      document.querySelector(`#reply${selectedFormIndex}`).classList.remove("visually-hidden")
      document.querySelector(`#reply${selectedFormIndex}`).classList.add("shown")
      let updateIndex = selectedFormIndex
      for (updateIndex; updateIndex <= intialReplyCount; updateIndex++) {
        document.getElementById(`reply${updateIndex}`).id = `reply${intialSelectedFormIndex}`
        document.getElementById(`inputDisplayName${updateIndex}`).id = `inputDisplayName${intialSelectedFormIndex}`
        document.getElementById(`inputUserName${updateIndex}`).id = `inputUserName${intialSelectedFormIndex}`
        document.getElementById(`inputDateTime${updateIndex}`).id = `inputDateTime${intialSelectedFormIndex}`
        document.getElementById(`inputPfp${updateIndex}`).id = `inputPfp${intialSelectedFormIndex}`
        document.getElementById(`inputBody${updateIndex}`).id = `inputBody${intialSelectedFormIndex}`
        document.getElementById(`inputVerified${updateIndex}`).id = `inputVerified${intialSelectedFormIndex}`
        document.getElementById(`inputRetweets${updateIndex}`).id = `inputRetweets${intialSelectedFormIndex}`
        document.getElementById(`inputQuoteTweets${updateIndex}`).id = `inputQuoteTweets${intialSelectedFormIndex}`
        document.getElementById(`inputLikes${updateIndex}`).id = `inputLikes${intialSelectedFormIndex}`
        document.querySelector(`#pageList #page${updateIndex}`).innerText = `${intialSelectedFormIndex}`
        document.querySelector(`#pageList #page${updateIndex}`).id = `page${intialSelectedFormIndex}`
        intialSelectedFormIndex++
      }
      document.querySelector(`#pageList #page${--selectedFormIndex}`).classList.add("active")
    }
  }
}