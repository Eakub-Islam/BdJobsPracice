using GymManagementSystem.DTO;
using GymManagementSystem.Handler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GymManagementSystem.Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberServiceHandler _memberServiceHandler;

        public MembersController(IMemberServiceHandler memberService)
        {
            _memberServiceHandler = memberService;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var members = await _memberServiceHandler.GetAllAsync();
            return View(members);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberDto memberDto)
        {
            var result = await _memberServiceHandler.AddAsync(memberDto); // Check the return value
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            // Handle the case where the addition fails
            ModelState.AddModelError(string.Empty, "Failed to add member.");
            return View(memberDto);
        }

        // GET: Members/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var memberDto = new MemberDto { MemberId = id };
            var member = await _memberServiceHandler.GetByIdAsync(memberDto);

            return View(member);
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MemberDto memberDto)
        {
            if (id != memberDto.MemberId)
            {
                return BadRequest("Member ID mismatch.");
            }

            var result = await _memberServiceHandler.UpdateAsync(memberDto); // Check the return value
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            // Handle the case where the update fails
            ModelState.AddModelError(string.Empty, "Failed to update member.");
            return View(memberDto);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var member = await _memberServiceHandler.GetByIdAsync(new MemberDto { MemberId = id });
            return member == null ? NotFound() : View(member);

        }

        // POST: Members/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(MemberDto memberDto)
        {
            var result = await _memberServiceHandler.DeleteAsync(memberDto); // Check the return value
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            // Handle the case where the deletion fails
            ModelState.AddModelError(string.Empty, "Failed to delete member.");
            return View(memberDto);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var memberDto = new MemberDto { MemberId = id };
            var member = await _memberServiceHandler.GetByIdAsync(memberDto);
            return member == null ? NotFound() : View(member);

        }
    }
}
